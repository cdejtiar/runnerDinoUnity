using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private Rigidbody2D rb; //Declaro
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] public float jumpForce;


    void Update()
    {
        rb.velocity = new Vector2(1, 0) * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(1, jumpForce); //SALTA!!!!! Falta que sea más natural.
        }
    }
    /*void OnMove(InputValue value)
    {
        var direction = value.Get<Vector2>();

        rb.velocity = direction * speed;


        if (direction.x != 0)
        {
            spriteRenderer.flipX = direction.x < 0;
        }
    }*/
}
