using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LevelFinished(int distancePlayed)
    {
        if (ScoreManager.Instance.HighScore < distancePlayed)
            ScoreManager.Instance.HighScore = distancePlayed;
        //Save(ScoreManager.Instance);
        //Debug.Log($"Highscore: {ScoreManager.Instance.HighScore}");
    }
}
