using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance { get; private set; }

    [SerializeField] private float startSeconds = 60f;
    [SerializeField] private TextMeshProUGUI timerText;

    public float StartSeconds => startSeconds;
    public float TimeRemaining { get; private set; }
    private bool isRunning = true;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    void Start()
    {
        TimeRemaining = startSeconds;
        UpdateUI();
    }

    void Update()
    {
        if (!isRunning) return;

        TimeRemaining -= Time.deltaTime;

        if (TimeRemaining <= 0f)
        {
            TimeRemaining = 0f;
            isRunning = false;

            GameController.NotifyTimeUp(startSeconds, TimeRemaining);
        }

        UpdateUI();
    }

    public void AddSeconds(float amount)
    {
        if (!isRunning) return;
        TimeRemaining += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (timerText != null)
            timerText.text = "Tempo: " + FormatClock(TimeRemaining);
    }

    public static string FormatClock(float seconds)
    {
        if (seconds < 0) seconds = 0;
        int mins = Mathf.FloorToInt(seconds / 60f);
        int secs = Mathf.FloorToInt(seconds % 60f);
        return $"{mins:00}:{secs:00}";
    }
}
