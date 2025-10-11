using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public GameObject endGamePanel;

    [SerializeField] private TextMeshProUGUI finalTimeText;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private GameObject timerText;

    private bool shownOnce;

    void FixedUpdate()
    {
        if (GameController.gameOver && !shownOnce)
        {
            shownOnce = true;

            if (endGamePanel != null) endGamePanel.SetActive(true);
            if (timerText != null) timerText.SetActive(false);

            // tempo final
            if (finalTimeText != null)
            {
                float t = GameController.finalRemaining;
                finalTimeText.text = "Tempo Restante: " + GameTimer.FormatClock(t);
            }

            // mensagem de vitória ou derrota
            if (resultText != null)
            {
                if (GameController.timeUp)
                {
                    resultText.text = "Você perdeu, tempo esgotado.";
                }
                else
                {
                    resultText.text = "Você venceu, todos os itens foram coletados.";
                }
            }
        }
    }
}
