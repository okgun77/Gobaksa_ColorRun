using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIController : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private GameObject         mainPanel;

    [Header("InGame")]
    [SerializeField] private GameObject         inGamePanel;
    [SerializeField] private TextMeshProUGUI    textInGameCurrentScore;
    [SerializeField] private TextMeshProUGUI    textInGameBestScore;

    [Header("GameOver")]
    [SerializeField] private GameObject         gameOverpanel;
    [SerializeField] private TextMeshProUGUI    textGameOverCurrentScore;
    [SerializeField] private TextMeshProUGUI    textGameOverBestScore;


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

    public void GameOver(int _current, int _best, bool _isBest)
    {
        inGamePanel.SetActive(false);
        gameOverpanel.SetActive(true);

        textGameOverCurrentScore.text = $"SCORE\n{_current:D4}";

        string bestScoreText = _isBest == true ? $"BEST(NEW)" : $"BEST";
        textGameOverBestScore.text = $"{bestScoreText}\n{_best:D4}";

    }

    public void OnClickMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
