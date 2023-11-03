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
    private float shieldDuration = 0.1f;
    private float shieldTimer = 0.0f;

    private int tempCurrent;

    public int Current => current;

    public int MaxHealth => maxHealth;

    private bool hasShieldBeenCalled = false;

    public void Start()
    {
        current = maxHealth;

    }
    public void Damage(int amount)
    {
        if (!hasShieldBeenCalled)
        {
            current -= amount;

            onChange.Invoke();

            if (current <= 0)
            {
                Instantiate(gameOverWindowPrefab, canvasTransform);
                Time.timeScale = 0;
            }
        }
        else
        {
            Shield();
        }



    }

    public void Shield()
    {

        hasShieldBeenCalled = true;
        tempCurrent = current;
        shieldTimer += Time.fixedDeltaTime;
        if (shieldTimer >= shieldDuration)
        {
            hasShieldBeenCalled = false;
        }

    }
    public void Healer(int amount)
    {

        current += amount;

        if (current > maxHealth)
        {
            current = maxHealth;
        }

        onChange.Invoke();

    }
}
