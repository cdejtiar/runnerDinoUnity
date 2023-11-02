using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private int cantidadARecuperar = 20; // Cantidad de salud que se recupera al recoger el power-up

    [SerializeField] private PlayerMove player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            other.GetComponent<Health>().Healer(cantidadARecuperar);

            // Destruye el power-up para que no se pueda recoger otra vez
            Destroy(gameObject);
        }
    }
}
