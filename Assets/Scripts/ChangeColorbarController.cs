using System.Collections;
using UnityEngine;

public class ChangeColorbarController : MonoBehaviour
{
    private SpriteRenderer[] renderers;
    private float fadeTime = 0.4f;

    public Color CurrentColor { private set; get; }


    private void Awake()
    {
        renderers = transform.GetComponentsInChildren<SpriteRenderer>();
    }

    public void SetColor(Color _color)
    {
        CurrentColor = _color;

        for (int i = 0; i < renderers.Length; ++i)
        {
            renderers[i].color = _color;
        }
    }

    
    private void OnEnable()
    {
        StartCoroutine(nameof(OnFadeLoop));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(OnFadeLoop));
    }


    private IEnumerator OnFadeLoop()
    {
        var waitForSeconds = new WaitForSeconds(fadeTime);

        while (true)
        {
            for (int i = 0; i < renderers.Length; ++i)
            {
                StartCoroutine(FadeEffect.Fade(renderers[i], 1f, 0f, fadeTime));
            }

            yield return waitForSeconds;

            for (int i = 0; i < renderers.Length; ++i)
            {
                StartCoroutine(FadeEffect.Fade(renderers[i], 0f, 1f, fadeTime));
            }

            yield return waitForSeconds;
        }
    }

}
