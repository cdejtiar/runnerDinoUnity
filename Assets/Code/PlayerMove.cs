using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private Rigidbody2D rb; //Declaro
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] public float jumpForce = 100;
    [SerializeField] public float gravityScale = 5;
    [SerializeField] public float fallGravityScale = 10;


    void Update()
    {
        rb.velocity = new Vector2(1, 0) * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += new Vector2(1, jumpForce) * speed; //SALTA!!!!! Falta que sea más natural.
            /*if (Mathf.Abs(rb.velocity.y) < 0.01f) // Solo permitir saltos cuando la velocidad vertical sea baja (en el suelo)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }*/
        }

        /*if (rb.velocity.y > 0)
        {
            rb.gravityScale = gravityScale;
        }
        else
        {
            rb.gravityScale = fallGravityScale;
        }/*
    }
    /*void OnMove(InputValue value)
    {
        var direction = value.Get<Vector2>();

        rb.velocity = direction * speed;


        if (direction.x != 0)
        {
            spriteRenderer.flipX = direction.x < 0;
        }*/
    }
}
