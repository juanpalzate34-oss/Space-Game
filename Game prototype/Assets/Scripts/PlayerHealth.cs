using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxVidas = 3;
    private int vidasActuales;

    public TextMeshProUGUI vidasText;   // Texto para mostrar las vidas
    public TextMeshProUGUI mensajeUI;   // Texto para mensajes ("Perdiste")
    public Transform puntoDeRespawn;    // Punto inicial del jugador

    private void Start()
    {
        vidasActuales = maxVidas;
        ActualizarUI();
        mensajeUI.text = ""; // Limpiamos el mensaje al inicio
    }

    public void TomarDaño(int daño)
    {
        vidasActuales -= daño;
        if (vidasActuales <= 0)
        {
            StartCoroutine(MostrarMensajePerdiste());
        }
        else
        {
            ActualizarUI();
        }
    }

    private IEnumerator MostrarMensajePerdiste()
    {
        mensajeUI.text = "¡Perdiste!"; 
        yield return new WaitForSeconds(2f); // mensaje visible por 2 segundos

        vidasActuales = maxVidas; 
        ActualizarUI();
        mensajeUI.text = ""; 

        // Reinicia posición del jugador
        transform.position = puntoDeRespawn.position;
    }

    private void ActualizarUI()
    {
        vidasText.text = "Vidas: " + vidasActuales;
    }
}


