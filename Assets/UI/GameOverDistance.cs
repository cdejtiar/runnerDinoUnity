using UnityEngine;
using TMPro;

public class GameOverWindow : MonoBehaviour
{
    public Distance distanceCalculator; // Arrastra la instancia de Distance en el Inspector de Unity
    public TextMeshProUGUI distanceText; // Asigna el campo de texto desde el Inspector

    void Start()
    {
        // Asegúrate de que el prefab del "GameOverWindow" tenga el campo de texto asignado.
        if (distanceText != null)
        {
            // Muestra la distancia recibida desde la instancia de Distance
            distanceText.text = "Score: " + distanceCalculator.currentDistance.ToString("F2") + " metros";
        }
    }
}
