using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPrefab : PowerUp
{


    public override void PowerUpUsage(Health health)
    {
        health.Shield();

    }
}
