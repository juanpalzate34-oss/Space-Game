using UnityEngine;
using TMPro; // <- necesario para TMP

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public TMP_Text fusiblesText;   // <- ahora usa TMP_Text
    public TMP_Text bateriasText;

    private int fusibles = 0;
    private int baterias = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddFusible(int amount)
    {
        fusibles += amount;
        UpdateUI();
    }

    public void AddBateria(int amount)
    {
        baterias += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        fusiblesText.text = "Fusibles: " + fusibles;
        bateriasText.text = "Baterías: " + baterias;
    }
}

