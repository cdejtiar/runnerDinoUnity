using UnityEngine;
using TMPro;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private Distance distance;
    public TextMeshProUGUI distanceText;

    void Start()
    {
        if (distanceText != null)
        {
            distanceText.text = "Actual Score: " + distance.CurrentDistance.ToString("F2") + " m";
        }
    }
}
