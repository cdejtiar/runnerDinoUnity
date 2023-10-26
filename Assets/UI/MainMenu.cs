using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public void MainMenuMode()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}