using System.Net.Mime;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Exit : MonoBehaviour
{
    public void ExitGame()
    {
        Time.timeScale = 1;
        Application.Quit(); //A chequear
    }
}