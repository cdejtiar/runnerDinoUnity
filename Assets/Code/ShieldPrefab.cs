using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPrefab : PowerUp
{
    [SerializeField] private Animator animator;
    void OnTriggerEnter2D(Collider2D other)
    {
        PowerUpUsage(other);
    }

    // Implementación del método abstracto
    public override void PowerUpUsage(Collider2D other)
    {
        other.GetComponent<Health>().Shield();
        animator.SetBool("isShieldMoving", true);
        Destroy(gameObject);
    }
}
