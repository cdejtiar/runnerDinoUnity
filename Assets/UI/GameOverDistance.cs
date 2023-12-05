using UnityEngine;
using TMPro;

public class GameOverWindow : MonoBehaviour
{

    //[SerializeField] private Distance Distance;

    public TextMeshProUGUI actualScore;
    public TextMeshProUGUI highScore;

    void Start()
    {

        //Debug.Log(distance.CurrentDistance);
        actualScore.text = "Actual Score: " + ScoreManager.Instance.ActualScore + " m";

        highScore.text = "Highscore: " + ScoreManager.Instance.HighScore + "m";
    }
}
