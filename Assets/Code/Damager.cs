using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cambiar nombre de archivo a damager 
public class Damager : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectPrefab; //esta al dope
    [SerializeField] private Tile data;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")//sacar esto
        {
            var health = other.gameObject.GetComponent<Health>();
            health.Damage(data.Damage);
            Destroy(gameObject);
        }
    }
}
