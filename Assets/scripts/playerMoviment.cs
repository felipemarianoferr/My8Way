using UnityEngine;

public class playerMoviment : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    AudioSource audio;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coletavel")
        {
            audio.Play();

            if (GameTimer.Instance != null)
                GameTimer.Instance.AddSeconds(3f);   // primeiro aplica o bônus
            if (CollectedHUD.Instance != null) CollectedHUD.Instance.AddOne();
            GameController.Collect();                 // depois registra a coleta
            Destroy(other.gameObject);
        }
    }
}
