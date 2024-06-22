using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AreaSpawner areaSpawner;
    [SerializeField] private PlayerColor playerColor;

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

            // CHangeCOlorBar 삭제
            Destroy(_collision.gameObject);
        }
        else if (_collision.CompareTag("Item"))
        {
            PlaySound(1);
            // 별 오브젝트 삭제
            Destroy(_collision.gameObject);
        }
    }

    public void PlaySound(int _index)
    {
        audioSource.PlayOneShot(clips[_index]);
    }

}
