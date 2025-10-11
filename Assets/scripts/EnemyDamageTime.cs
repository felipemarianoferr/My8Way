using UnityEngine;

public class EnemyDamageTime : MonoBehaviour
{
    [SerializeField] private float penaltySeconds = 10f;
    [SerializeField] private float hitCooldown = 0.8f;

    private bool canHit = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canHit) return;
        if (!other.CompareTag("Player")) return;
        if (GameTimer.Instance == null) return;

        GameTimer.Instance.AddSeconds(-Mathf.Abs(penaltySeconds));
        StartCoroutine(Cooldown());
    }

    private System.Collections.IEnumerator Cooldown()
    {
        canHit = false;
        yield return new WaitForSeconds(hitCooldown);
        canHit = true;
    }
}
