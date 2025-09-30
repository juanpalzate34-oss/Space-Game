using UnityEngine;

public class Fusible : MonoBehaviour
{
    public int cantidad = 1; // cuantos fusibles da este objeto

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Has obtenido un fusible!");
            InventoryManager.instance.AddFusible(cantidad);
            Destroy(gameObject);
        }
    }
}

