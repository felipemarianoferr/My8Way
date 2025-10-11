using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Vector2 direction = Vector2.up; // Direção: (0,1)=cima, (1,0)=direita etc.
    [SerializeField] private float distance = 9f;            // Distância total do movimento
    [SerializeField] private float speed = 2f;               // Velocidade de movimento

    private Vector3 startPos;
    private bool movingForward = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calcula posição ao longo do eixo de movimento
        float step = speed * Time.deltaTime;
        transform.Translate(direction * step * (movingForward ? 1 : -1));

        // Inverte direção quando ultrapassa o limite
        if (Vector3.Distance(startPos, transform.position) >= distance)
        {
            movingForward = !movingForward;
        }
    }
}
