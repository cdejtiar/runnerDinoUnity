using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] public Vector2 velocity;
    [SerializeField] private float maxXVelocity = 100;

    [SerializeField] private float gravity = -100;

    [SerializeField] private float acceleration = 10;
    [SerializeField] private float maxAcceleration = 10;

    [SerializeField] private float distance = 0;

    [SerializeField] private float jumpVelocity = 20; //Fuerza de salto
    [SerializeField] private float groundHeight = 10; //Depende de donde está el player, donde va a aterrizar
    [SerializeField] private bool isGrounded = false;

    [SerializeField] private bool isHoldingJump = false; //Si está presionando el botón de salto
    [SerializeField] private float maxHoldJump = 0.4f; //Cuanto tiempo puede mantener presionado el botón de salto
    [SerializeField] private float holdJumpTimer = 0f;

    [SerializeField] private float jumpGroundThreshold = 0.3f; //Distancia máxima que puede estar del suelo para poder saltar

    [SerializeField] private Rigidbody2D rb; //Declaro
    [SerializeField] private SpriteRenderer spriteRenderer;

    public float Distance => distance;

    void Update()
    {
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight); //Distancia entre el player y el suelo

        if (isGrounded || groundDistance <= jumpGroundThreshold) //Si está en el suelo o está cerca del suelo
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                holdJumpTimer = 0; //Reseteo el timer
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }
        /*rb.velocity = new Vector2(1, 0) * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += new Vector2(1, jumpForce) * speed; //SALTA!!!!! Falta que sea más natural.
            /*if (Mathf.Abs(rb.velocity.y) < 0.01f) // Solo permitir saltos cuando la velocidad vertical sea baja (en el suelo)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }*/
        //}
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(1, 0) * speed; //Se sigue trabando

        Vector2 pos = transform.position; //Posición actual del player

        if (!isGrounded)
        {

            if (isHoldingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime; //Corre el timer
                if (holdJumpTimer >= maxHoldJump)
                {
                    isHoldingJump = false; //Si se pasa del tiempo, deja de saltar
                }
            }

            pos.y += velocity.y * Time.fixedDeltaTime; //Aumenta la posición en y

            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;//Caída
            }

            Vector2 rayOrigin = new Vector2(pos.x + 0.7f, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance);
            if (hit2D.collider != null)
            {
                StartingGround ground = hit2D.collider.GetComponent<StartingGround>();
                GroundPrefab groundPrefab = hit2D.collider.GetComponent<GroundPrefab>();
                if (ground != null || groundPrefab != null)
                {
                    pos.y = groundHeight;
                    isGrounded = true;
                }

            }
            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.cyan);

            // if (pos.y <= groundHeight) //Si está en el suelo
            // {
            //     pos.y = groundHeight;
            //     isGrounded = true;
            // }
        }

        distance += velocity.x * Time.fixedDeltaTime; //Calcula la distancia que recorrimos

        if (isGrounded)
        { //Si estamos en el suelo

            float velocityRatio = velocity.x / maxXVelocity; //Va de 0 a 1
            acceleration = maxAcceleration * (1 - velocityRatio); //Hace que aumente la velocidad de forma lenta mientras que la aceleración baja, también de forma lenta

            velocity.x += acceleration * Time.fixedDeltaTime; //Aceleramos la velociddad en x

            if (velocity.x >= maxXVelocity)
            { //Evito que tenga velocidad que aumente infinitamente.
                velocity.x = maxXVelocity;
            }
        }

        transform.position = pos;
    }
}