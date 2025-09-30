using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class IntroManager : MonoBehaviour
{
    public TextMeshProUGUI introText; // arrastra aquí tu texto
    public float tiempoVisible = 7f;  // segundos que el texto estará visible
    public float tiempoFade = 2f;     // duración del desvanecimiento

    private Image panelImage;

    private void Start()
    {
        panelImage = GetComponent<Image>();
        StartCoroutine(IntroSequence());
    }

    IEnumerator IntroSequence()
    {
        // Espera con el texto visible
        yield return new WaitForSeconds(tiempoVisible);

        // Fade out del panel y del texto
        float t = 0;
        Color colorPanel = panelImage.color;
        Color colorTexto = introText.color;

        while (t < tiempoFade)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / tiempoFade);

            panelImage.color = new Color(colorPanel.r, colorPanel.g, colorPanel.b, alpha);
            introText.color = new Color(colorTexto.r, colorTexto.g, colorTexto.b, alpha);

            yield return null;
        }

        // Desactiva la pantalla negra al terminar
        gameObject.SetActive(false);
    }
}
