using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float yOffset = 3;

    private void LateUpdate()
    {
        if (target == null) return;

        transform.position = new Vector3(0, target.position.y + yOffset, -10);
    }
}
