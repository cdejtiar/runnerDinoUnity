using TMPro;
using UnityEngine;

public class HighscoreMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI highScore;

    void Start()
    {
        highScore.text = "Highscore: " + ScoreManager.Instance.HighScore + "m";
    }
}

