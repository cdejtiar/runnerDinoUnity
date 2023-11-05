using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private int cantidadARecuperar = 50; // Cantidad de salud que se recupera al recoger el power-up

    [SerializeField] private Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "Healing")
            {
                other.GetComponent<Health>().Healer(cantidadARecuperar);
                animator.SetBool("isHealingMoving", true);
            }
            else if (gameObject.tag == "Shield")
            {
                other.GetComponent<Health>().Shield();
                animator.SetBool("isShieldMoving", true);
            }

            // Destruye el power-up para que no se pueda recoger otra vez
            Destroy(gameObject);
        }
    }

    void OnMove()
    {
        if (gameObject.tag == "Healing")
        {
            animator.SetBool("isHealingMoving", false);
        } else if (gameObject.tag == "Shield")
        {
            animator.SetBool("isShieldMoving", false);
        }
    }
}
