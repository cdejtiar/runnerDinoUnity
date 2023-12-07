using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{

    public abstract void PowerUpUsage(Health other);
    void OnTriggerEnter2D(Collider2D other)
    {
        PowerUpUsage(other.GetComponent<Health>());
        Destroy(gameObject);
    }
}