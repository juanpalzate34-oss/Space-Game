using UnityEngine;

public class Bateria : MonoBehaviour
{
    public int cantidad = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.instance.AddBateria(cantidad);
            Destroy(gameObject);
        }
    }
}

