using UnityEngine;

public class PatternController : MonoBehaviour
{
    [SerializeField] private bool isColorControl = true;

    // [SerializeField] private SpriteRenderer[] renderers;

    public void SetColor(Color[] _colors, Color _areaColor)
    {
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < renderers.Length; ++i)
        {
            renderers[i].color = _colors[Random.Range(0, _colors.Length)];
        }

        if (isColorControl == true)
        {
            int areaColorIndex = Random.Range(0, renderers.Length);
            renderers[areaColorIndex].color = _areaColor;
        }
    }
}
