using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    private int healAmount = 50; // Cantidad de salud que se recupera al recoger el power-up

    [SerializeField] private Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")  // Porque lo dijo ChatGPT?
        {
            if (gameObject.tag == "Healing")
            {
                other.GetComponent<Health>().Healer(healAmount);
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

    protected abstract void DoPowerUp();

    // void OnMove()
    // {
    //     if (gameObject.tag == "Healing")
    //     {
    //         animator.SetBool("isHealingMoving", false);
    //     }
    //     else if (gameObject.tag == "Shield")
    //     {
    //         animator.SetBool("isShieldMoving", false);
    //     }
    // }
}
