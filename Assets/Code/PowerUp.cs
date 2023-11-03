using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private int cantidadARecuperar = 50; // Cantidad de salud que se recupera al recoger el power-up

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "Healing")
            {
                other.GetComponent<Health>().Healer(cantidadARecuperar);
            }
            else if (gameObject.tag == "Shield")
            {
                other.GetComponent<Health>().Shield();
            }

            // Destruye el power-up para que no se pueda recoger otra vez
            Destroy(gameObject);
        }
    }
}
