using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AreaSpawner areaSpawner;

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("ChangeColorBar"))
        {
            // 이전 구역 삭제
            areaSpawner.DestroyArea();
            // 구역 생성
            areaSpawner.SpawnArea();

            // CHangeCOlorBar 삭제
            Destroy(_collision.gameObject);
        }
    }
}
