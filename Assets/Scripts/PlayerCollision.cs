using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AreaSpawner areaSpawner;
    [SerializeField] private PlayerColor playerColor;
    [SerializeField] private PlayerData  playerData;

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
                // 게임오버
                Debug.Log("Player Die");
            }
        }
        
    }

    public void PlaySound(int _index)
    {
        audioSource.PlayOneShot(clips[_index]);
    }

}
