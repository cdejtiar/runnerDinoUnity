using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cambiar nombre de archivo a damager 
public class Damager : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectPrefab;
    [SerializeField] private Obstacle data;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("hit");
            var health = other.gameObject.GetComponent<Health>();
            health.Damage(data.Damage);

            Destroy(gameObject);
        }
        //Debug.Log("hit");

        /*var trigger = gameObjectPrefab.GetComponent<Collider2D>();
        trigger.isTrigger = (health.Current != startingHealth) ? true : false; // Me gustaría que el trigger solo se active cuando el obstáculo es Lava
        */
    }
}
