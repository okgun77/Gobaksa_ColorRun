using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AreaSpawner areaSpawner;
    [SerializeField] private PlayerColor playerColor;
    [SerializeField] private PlayerData  playerData;

    /* [Header("Player Die")]
    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject playerRenderer;
    [SerializeField] private Collider2D playerCollider; */
    [SerializeField] private ParticleSystem playerDieEffect;
    [SerializeField] private UnityEvent onPlayerDie;


    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] clips;
    
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("ChangeColorBar"))
        {
            PlaySound(0);
            // 플레이어 색상 변경
            playerColor.SetColor(_collision.GetComponent<ChangeColorbarController>().CurrentColor);

            // 이전 구역 삭제
            areaSpawner.DestroyArea();
            // 구역 생성
            areaSpawner.SpawnArea();

            // CHangeColorBar 삭제
            Destroy(_collision.gameObject);
        }
        else if (_collision.CompareTag("Item"))
        {
            PlaySound(1);
            // 별 오브젝트 삭제
            Destroy(_collision.gameObject);
        }
        else if (_collision.CompareTag("Obstacle"))
        {
            // 같은 색상의 오브젝트와 충돌했을 때
            if (_collision.GetComponent<SpriteRenderer>().color.Equals(playerColor.CurrentColor))
            {
                PlaySound(2);
                // 도형 오브젝트 삭제
                Destroy(_collision.gameObject);
                // 플레이어 점수 증가
                playerData.CurrentScore++;
            }
            else
            {
                PlaySound(3);
                
                // 플레이어 사망 효과 색상 설정
                ParticleSystem.MainModule main = playerDieEffect.main;
                main.startColor = playerColor.CurrentColor;

                /* //플레이어 렌더러, 충돌 컴포넌트 비활성화
                playerRenderer.SetActive(false);
                playerCollider.enabled = false;

                // 플레이어 사망 효과 재생
                playerDieEffect.gameObject.SetActive(true);

                // GameController에 있는 GameOver 메소드 호출
                gameController.GameOver(); */

                onPlayerDie?.Invoke();
            }
        }
        
    }

    public void PlaySound(int _index)
    {
        audioSource.PlayOneShot(clips[_index]);
    }

}
