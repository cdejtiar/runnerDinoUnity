using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cambiar nombre de archivo a damager 
public class Damager : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectPrefab;
    [SerializeField] private Obstacle data;
    public void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("hit");
        var health = other.gameObject.GetComponent<Health>();
        var startingHealth = health.Current;
        health.Damage(data.Damage);

        Destroy(gameObject);
        /*var trigger = gameObjectPrefab.GetComponent<Collider2D>();
        trigger.isTrigger = (health.Current != startingHealth) ? true : false; // Me gustaría que el trigger solo se active cuando el obstáculo es Lava
        */
    }
}
