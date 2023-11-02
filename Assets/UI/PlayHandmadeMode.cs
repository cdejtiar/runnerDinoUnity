using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayHandmadeMode : MonoBehaviour
{
    public void PlayHandmade()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayableLevelHandmade");
    }
}