using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject gameOverWindowPrefab;
    [SerializeField] private Transform canvasTransform;
    [SerializeField] private UnityEngine.Events.UnityEvent onChange;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int current = 1;

    public int Current => current;

    public int MaxHealth => maxHealth;

    public void Start()
    {
        current = maxHealth;
    }
    public void Damage(int amount)
    {

        current -= amount;

        onChange.Invoke();

        if (current <= 0)
        {
            Instantiate(gameOverWindowPrefab, canvasTransform);
            Time.timeScale = 0;
        }
    }
}
