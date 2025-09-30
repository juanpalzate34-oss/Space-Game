using UnityEngine;

public class Bateria : MonoBehaviour
{
    public int cantidad = 1; // cuantas baterías da este objeto

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Has obtenido una batería!");
            InventoryManager.instance.AddBateria(cantidad);
            Destroy(gameObject);
        }
    }
}
