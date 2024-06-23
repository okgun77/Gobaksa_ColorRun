using UnityEngine;
using System.Collections;
using TMPro;

public class UITextBlink : MonoBehaviour
{
    [SerializeField] private float fadeTime = 0.4f;

    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(OnBlink));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator OnBlink()
    {
        while (true)
        {
            yield return StartCoroutine(FadeEffect.Fade(text, 1, 0, fadeTime));

            yield return StartCoroutine(FadeEffect.Fade(text, 0, 1, fadeTime));
        }
    }

}
