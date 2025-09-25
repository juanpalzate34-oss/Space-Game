using UnityEngine;

public class Fusible : MonoBehaviour
{
    public int cantidad = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.instance.AddFusible(cantidad);
            Destroy(gameObject);
        }
    }
}
