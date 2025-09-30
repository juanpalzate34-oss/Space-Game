using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // velocidad de movimiento

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Leer entrada (WASD o flechas)
        movement.x = Input.GetAxisRaw("Horizontal"); // -1, 0, 1
        movement.y = Input.GetAxisRaw("Vertical");   // -1, 0, 1
    }

    private void FixedUpdate()
    {
        // Aplicar movimiento en físicas
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
