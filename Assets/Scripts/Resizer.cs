using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    [SerializeField] private Vector3    start;
    [SerializeField] private Vector3    end;
    [SerializeField] private float      resizeTime = 1;

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
            yield return StartCoroutine(ScaleTo(start, end));

            yield return StartCoroutine(ScaleTo(end, start));
        }
    }

    private IEnumerator ScaleTo(Vector3 _start, Vector3 _end)
    {
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime / resizeTime;

            transform.localScale = Vector3.Lerp(_start, _end, percent);

            yield return null;
        }
    }
}
