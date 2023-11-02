using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private int cantidadARecuperar = 20; // Cantidad de salud que se recupera al recoger el power-up

    [SerializeField] private PlayerMove player;
    void Update()
    {
        //Implementar el raycast para reconocer que está el powerup
        Vector2 pos = player.transform.position;
        Vector2 rayOrigin = new Vector2(pos.x + 0.8f, pos.y - 0.23f);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = player.velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance);
            if (hit2D.collider != null)
            {
                // Recuperar la salud del jugador
                player.GetComponent<Health>().Healer(cantidadARecuperar);
            }
            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.yellow);
    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            other.GetComponent<Health>().Healer(cantidadARecuperar);

            // Destruye el power-up para que no se pueda recoger otra vez
            Destroy(gameObject);
        }
    }*/
}
