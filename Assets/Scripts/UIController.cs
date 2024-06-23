using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIController : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private GameObject mainPanel;

    [Header("InGame")]
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private TextMeshProUGUI textInGameCurrentScore;
    [SerializeField] private TextMeshProUGUI textInGameBestScore;


    public void GameStart()
    {
        mainPanel.SetActive(false);
        inGamePanel.SetActive(true);

        int bestScore = PlayerPrefs.GetInt(Constants.BESTSCORE);
        textInGameBestScore.text = $"BEST\n{bestScore:D4}";
    }

    public void UpdateCurrentScore(int _score)
    {
        textInGameCurrentScore.text = $"{_score:00}";
    }
}
