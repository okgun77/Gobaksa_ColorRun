using TMPro.EditorUtilities;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    [SerializeField] private ChangeColorbarController   colorBar;
    [SerializeField] private PatternController[]        patterns;
    [SerializeField] private SpriteRenderer[]           nonPatterns;
    [SerializeField] private int                        activeStarCount = 10;
    [SerializeField] private GameObject[]               stars;

    public void Setup(Color[] _colors)
    {
        // 임의의 색상 설정
        Color areaColor = _colors[Random.Range(0, _colors.Length)];

        // Color Bar 색상 설정
        colorBar.SetColor(areaColor);

        // 패턴 오브젝트 색상 설정
        for (int i = 0; i < patterns.Length; ++i)
        {
            patterns[i].SetColor(_colors, areaColor);
        }

        // 비 패턴 오브젝트 색상 설정
        for (int i = 0; i < nonPatterns.Length; ++i)
        {
            nonPatterns[i].color = _colors[Random.Range(0, _colors.Length)];
        }

        // 별 아이템 오브젝트 활성/비활성화 설정
        int[] starIndexs = Utils.RandomNumerics(stars.Length, stars.Length);
        for (int i = 0; i < stars.Length; ++i)
        {
            stars[i].SetActive(false);
        }
        for (int i = 0; i < stars.Length; ++i)
        {
            stars[starIndexs[i]].SetActive(true);

            if (activeStarCount <= i+1)
            {
                break;
            }
        }
    }


}
