using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class PlayerMovement : MonoBehaviour
{
    private readonly float minX = -2.75f;
    private readonly float maxX = 2.75f;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float yMoveSpeed = 2f; // 전진 이동 속도

    private float startPointX;
    private float finalPointX;

    private void Awake()
    {
        startPointX = 0;
        finalPointX = 0;
    }

    private void Update()
    {
        MoveToX();
        MoveToY();
    }

    private void MoveToX()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPointX = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
            startPointX -= transform.position.x;
        }
        
        if (Input.GetMouseButton(0))
        {
            finalPointX = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
            finalPointX -= startPointX;

            // 화면 경계를 넘어가지 않도록 설정
            finalPointX = Mathf.Clamp(finalPointX, minX, maxX);

            // 플레이어의 x 위치 설정
            // trausnform.position = new Vctor2(finalPointX, transform.position.y, 0);
            float velocityY = 0.0f;
            float x = Mathf.SmoothDamp(transform.position.x, finalPointX, ref velocityY, 0.02f);
            transform.position = new Vector3(x, transform.position.y, 0);
        }    }

    private void MoveToY()
    {
        // 플레이어의 y 위치 설정
        transform.position += Vector3.up * yMoveSpeed * Time.deltaTime;
    }
}
