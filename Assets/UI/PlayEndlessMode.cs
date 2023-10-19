using UnityEngine.SceneManagement;
using UnityEngine;


public class PlayEndlessMode : MonoBehaviour
{
    public void PlayEndless()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayableLevelEndless");
    }
}