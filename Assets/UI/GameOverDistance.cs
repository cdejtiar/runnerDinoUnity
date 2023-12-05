using UnityEngine;
using TMPro;

public class GameOverWindow : MonoBehaviour
{

    private Distance distance;

    public TextMeshProUGUI actualScore;
    public TextMeshProUGUI highScore;

    void Start()
    {

        //Debug.Log(distance.CurrentDistance);
        actualScore.text = "Actual Score: " + distance.CurrentDistance.ToString("F2") + " m";
        highScore.text = "Highscore: " + ScoreManager.Instance.HighScore + "m";
    }
}
