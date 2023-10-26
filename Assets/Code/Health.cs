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

    private bool hasHealerBeenCalled = false;

    public void Start()
    {
        current = maxHealth;
        Debug.Log("Health inicial: " + current);
    }
    public void Damage(int amount)
    {
        current -= amount;

        onChange.Invoke();

        Debug.Log("Health at Damage: " + current);

        if (current <= 0)
        {
            Instantiate(gameOverWindowPrefab, canvasTransform);
            Time.timeScale = 0;
        }
    }

    public void Healer(int amount)
    {
        if(!hasHealerBeenCalled){
            current += amount;
            hasHealerBeenCalled = true;

            if (current > maxHealth)
            {
                current = maxHealth;
            }

            Debug.Log("Health at Healer: " + current);

            onChange.Invoke();
        }
    }
}
