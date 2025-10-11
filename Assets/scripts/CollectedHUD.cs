using UnityEngine;
using TMPro;

public class CollectedHUD : MonoBehaviour
{
    public static CollectedHUD Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI collectedText;
    [SerializeField] private int total = 7;

    private int current;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    void OnEnable()
    {
        current = 0;
        UpdateUI();
    }

    public void AddOne()
    {
        current++;
        if (current < 0) current = 0;
        if (current > total) current = total;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (collectedText != null)
            collectedText.text = current + "/" + total + " coletadas";
    }
}
