using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPrefab : PowerUp
{

    [SerializeField] private Animator animator;


    private int healAmount = 50;

    void OnTriggerEnter2D(Collider2D other)
    {
        PowerUpUsage(other);
    }

    // Implementación del método abstracto
    public override void PowerUpUsage(Collider2D other)
    {
        other.GetComponent<Health>().Healer(healAmount);
        animator.SetBool("isHealingMoving", true);
        Destroy(gameObject);
    }




}
