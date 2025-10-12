using UnityEngine;

public class EnemyDamageTime : MonoBehaviour
{
    [SerializeField] private float penaltySeconds = 10f;
    [SerializeField] private float hitCooldown = 0.8f;

    // NOVO: som ao encostar no inimigo
    [SerializeField] private AudioClip hitClip;
    [SerializeField] [Range(0f, 1f)] private float hitVolume = 1f;

    private bool canHit = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canHit) return;
        if (!other.CompareTag("Player")) return;
        if (GameTimer.Instance == null) return;

        GameTimer.Instance.AddSeconds(-Mathf.Abs(penaltySeconds));

        // NOVO: toca o som de “dano” usando o mesmo AudioSource do player
        if (hitClip != null)
        {
            var src = other.GetComponent<AudioSource>();
            if (src != null) src.PlayOneShot(hitClip, hitVolume);
            else AudioSource.PlayClipAtPoint(hitClip, other.transform.position, hitVolume);
        }

        StartCoroutine(Cooldown());
    }

    private System.Collections.IEnumerator Cooldown()
    {
        canHit = false;
        yield return new WaitForSeconds(hitCooldown);
        canHit = true;
    }
}
