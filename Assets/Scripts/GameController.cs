using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController uiController;

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
}
