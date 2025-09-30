using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float velocidad = 2f;
    public float tiempoCambio = 2f;

    private Rigidbody2D rb;
    private Vector2 direccionMovimiento;
    private float temporizador;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CambiarDireccion();
    }

    private void Update()
    {
        temporizador += Time.deltaTime;

        if (temporizador >= tiempoCambio)
        {
            CambiarDireccion();
            temporizador = 0f;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direccionMovimiento * velocidad * Time.fixedDeltaTime);
    }

    private void CambiarDireccion()
    {
        // Dirección aleatoria: arriba, abajo, izquierda o derecha
        int dir = Random.Range(0, 4);

        switch (dir)
        {
            case 0: direccionMovimiento = Vector2.up; break;
            case 1: direccionMovimiento = Vector2.down; break;
            case 2: direccionMovimiento = Vector2.left; break;
            case 3: direccionMovimiento = Vector2.right; break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Hace daño al jugador si tiene el script de vida
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TomarDaño(1);
            }
        }
    }
}
