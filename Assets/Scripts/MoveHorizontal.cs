using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    [SerializeField] private float start;
    [SerializeField] private float end;
    [SerializeField] private float unitPerSecond = 1;

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        while (true)
        {
            yield return StartCoroutine(MoveTo(start, end));

            yield return StartCoroutine(MoveTo(end, start));
        }
    }

    private IEnumerator MoveTo(float _start, float _end)
    {
        float percent   = 0;
        float distance  = Mathf.Abs(_end - _start);
        float moveTime  = distance * unitPerSecond;

        while (percent < 1)
        {
            percent += Time.deltaTime / moveTime;

            Vector3 position    = transform.position;
            position.x          = Mathf.Lerp(_start, _end, percent);
            transform.position  = position;

            yield return null;
        }
    }
}
