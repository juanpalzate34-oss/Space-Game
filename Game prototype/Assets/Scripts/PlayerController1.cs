using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // velocidad del jugador
    private Rigidbody2D rb;      // referencia al Rigidbody2D
    private Vector2 moveInput;   // vector de entrada

    void Start()
    {
        // Busca el Rigidbody2D en el mismo objeto
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura las teclas WASD o flechas
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D o ← →
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S o ↑ ↓

        // Normaliza el vector para que diagonal no sea más rápida
        moveInput.Normalize();
    }

    void FixedUpdate()
    {
        // Aplica movimiento con físicas
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
