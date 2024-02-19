using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int highScore = 0;
    public int HighScore
    {
        get => highScore;
        set
        {
            this.highScore = value;
            Persist();
        }
    }
    public int ActualScore = 0;

    public Text DebugText;
    public void Awake()
    {

        if (ScoreManager.Instance == null)
        {
            ScoreManager.Instance = this;
            DontDestroyOnLoad(gameObject);

            var ds = new DataService("databaseRunnerDino.db");
            ds.CreateDB();
            
            var Highscore = ds.GetHighscore();
            this.HighScore = highScore;

            ToConsole("highscore:" + HighScore);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Persist()
    {
        var ds = new DataService("databaseRunnerDino.db");
        ds.UpdateHighscore(this.highScore);
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
