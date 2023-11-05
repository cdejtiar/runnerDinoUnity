using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour
{
    public void ExitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
