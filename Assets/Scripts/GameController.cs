using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    [SerializeField] private PlayerData playerData;

    public bool IsGamePlay { private set; get; }

    private IEnumerator Start()
    {
        while (true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                GameStart();

                yield break;
            }

            yield return null;
        }
    }

    private void GameStart()
    {
        IsGamePlay = true;

        uiController.GameStart();
    }

    public void GameOver()
    {
        IsGamePlay = false;

        StartCoroutine(nameof(OnGameOver));
    }

    private IEnumerator OnGameOver()
    {
        float percent = 0;
        float time = 1.5f;

        while (percent < time)
        {
            percent += Time.deltaTime;

            yield return null;
        }

        // 현재 점수가 최고 점수보다 높으면 최고 점수 갱신
        bool isBestScore = false;
        int bestScore = PlayerPrefs.GetInt(Constants.BESTSCORE);

        if (bestScore < playerData.CurrentScore)
        {
            isBestScore = true;
            bestScore = playerData.CurrentScore;
            PlayerPrefs.SetInt(Constants.BESTSCORE, bestScore);
        }

        // 게임 오버 UI 출력
        uiController.GameOver(playerData.CurrentScore, bestScore, isBestScore);
    }
}
