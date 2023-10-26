using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectPrefab;
    [SerializeField] private Obstacle data;
    private void OnCollisionEnter2D(Collision2D other)
    {
        var health = other.gameObject.GetComponent<Health>();
        var startingHealth = health.Current;
        health.Damage(data.Damage);

        /*var trigger = gameObjectPrefab.GetComponent<Collider2D>();
        trigger.isTrigger = (health.Current != startingHealth) ? true : false; // Me gustaría que el trigger solo se active cuando el obstáculo es Lava
        */
    }
}
