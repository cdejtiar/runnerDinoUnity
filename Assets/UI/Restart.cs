using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Restart : MonoBehaviour
{
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayableLevelEndless");
    }

    public void RestartLevel2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayableLevelHandmade");
    }
}
