using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("saliendo!");
        Time.timeScale = 1;
        Application.Quit(); //A chequear
    }
}
