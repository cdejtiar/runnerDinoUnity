using TMPro;
using UnityEngine;

public class GameOverWindow : MonoBehaviour
{
    public DistanceCounter distanceCalculator;
    public TextMeshProUGUI distanceText;

    void Start()
    {
        if (distanceText != null)
        {
            distanceText.text = "Score: " + distanceCalculator.currentDistance.ToString("F2") + " m";
        }
    }
}
