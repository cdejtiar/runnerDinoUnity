using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectPrefab;
    private void OnCollisionEnter2D(Collision2D other)
    {
        var health = other.gameObject.GetComponent<Health>();
        var startingHealth = health.Current;
        health.Damage(25);

        var trigger = gameObjectPrefab.GetComponent<Collider2D>();
        trigger.isTrigger = (health.Current != startingHealth) ? true : false; // "funciona"
    }
}
