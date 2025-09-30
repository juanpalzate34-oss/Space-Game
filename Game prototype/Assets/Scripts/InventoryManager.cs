using UnityEngine;
using TMPro; // para TextMeshPro

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [Header("Coleccionables Totales en el Nivel")]
    public int totalFusibles = 3;
    public int totalBaterias = 3;

    [Header("Contadores actuales")]
    public int fusibles = 0;
    public int baterias = 0;

    [Header("UI Elements")]
    public TMP_Text fusiblesText;
    public TMP_Text bateriasText;
    public TMP_Text mensajeFinalText;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        ActualizarUI();
        mensajeFinalText.gameObject.SetActive(false);
    }

    public void AddFusible(int cantidad)
    {
        fusibles += cantidad;
        ActualizarUI();
        RevisarVictoria();
    }

    public void AddBateria(int cantidad)
    {
        baterias += cantidad;
        ActualizarUI();
        RevisarVictoria();
    }

    private void ActualizarUI()
    {
        if (fusiblesText != null)
            fusiblesText.text = "Fusibles: " + fusibles + "/" + totalFusibles;

        if (bateriasText != null)
            bateriasText.text = "Baterías: " + baterias + "/" + totalBaterias;
    }

    private void RevisarVictoria()
    {
        if (fusibles >= totalFusibles && baterias >= totalBaterias)
        {
            mensajeFinalText.gameObject.SetActive(true);
            mensajeFinalText.text = "¡Lo has logrado!\nGracias por jugar :)";
        }
    }
}

