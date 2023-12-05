using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int HighScore = 0;

    public void Awake()
    {
        if (ScoreManager.Instance == null)
        {
            ScoreManager.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
