using UnityEngine;
using TMPro;

public class GameOverWindow : MonoBehaviour
{
    public Distance distanceCalculator;
    public TextMeshProUGUI distanceText;

    void Start()
    {
        if (distanceText != null)
        {
            distanceText.text = "Actual Score: " + distanceCalculator.currentDistance.ToString("F2") + " m";
        }
    }
}
