using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPrefab : PowerUp
{
    private const int healAmount = 50;

    public override void PowerUpUsage(Health health)
    {
        health.Healer(healAmount);
    }
}
