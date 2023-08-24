using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject gameOverWindow;
    [SerializeField] private int current = 1;


    public void Damage(int amount)
    {
        current -= amount;
        if (current <= 0)
        {
            gameOverWindow.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
