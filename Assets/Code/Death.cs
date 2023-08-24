using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var health = other.gameObject.GetComponent<Health>();
        health.Damage(1);
    }
    /*   void OnCollisionEnter2D(Collision2D other)
       {
           var health = other.GameObject.GetComponent<Health>();
           health.Damage(1);
       }*/

}
