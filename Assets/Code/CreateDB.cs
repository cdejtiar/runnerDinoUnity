using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateDBScript : MonoBehaviour
{

    public Text DebugText;

    // Use this for initialization
    void Start()
    {
        StartSync();
    }

    private void StartSync()
    {
        var ds = new DataService("tempDatabase.db");
        ds.CreateDB();
        var HighScore = ds.GetHighscore();
        ToConsole("highscore:" + HighScore);

    }

    private void ToConsole(IEnumerable<ScoreManager2> HighScore)
    {

        ToConsole(HighScore.ToString());

    }

    private void ToConsole(string msg)
    {
        DebugText.text += System.Environment.NewLine + msg;
        Debug.Log(msg);
    }
}