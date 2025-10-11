using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public GameObject endGamePanel;
    [SerializeField] private TextMeshProUGUI finalTimeText;
    [SerializeField] private GameObject timerText;

    private bool shownOnce;

    void FixedUpdate()
    {
        if (GameController.gameOver && !shownOnce)
        {
            shownOnce = true;

            if (endGamePanel != null) endGamePanel.SetActive(true);
            if (timerText != null) timerText.SetActive(false);

            if (finalTimeText != null)
            {
                string formatted = GameTimer.FormatClock(GameController.finalElapsed);
                finalTimeText.text = "Tempo total: " + formatted;
            }
        }
    }
}
