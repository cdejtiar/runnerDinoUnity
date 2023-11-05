using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] public Vector2 velocity;
    [SerializeField] private float maxXVelocity = 80;

    [SerializeField] private float gravity = -70;

    [SerializeField] private float acceleration = 1;
    [SerializeField] private float maxAcceleration = 1;

    [SerializeField] private float distance = 0;

    [SerializeField] private float jumpVelocity = 16; //Fuerza de salto
    [SerializeField] private float groundHeight = -2.435f; //Depende de donde está el player, donde va a aterrizar
    private bool isGrounded = false;

    private bool isHoldingJump = false; //Si está presionando el botón de salto
    [SerializeField] private float maxHoldJump = 0.4f; //Cuanto tiempo puede mantener presionado el botón de salto
    [SerializeField] private float holdJumpTimer = 0f;

    [SerializeField] private float jumpGroundThreshold = 0.3f; //Distancia máxima que puede estar del suelo para poder saltar

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Animator animator;

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

        if (!Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }
    }

    void FixedUpdate()
    {
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
            animator.SetBool("jumping", groundHeight < pos.y);

            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime; //Caída
            }

            Vector2 rayOrigin = new Vector2(pos.x + 0.7f, pos.y - 0.3f);
            Vector2 rayDirection = Vector2.down;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance);
            if (hit2D.collider != null)
            {
                StartingGround ground = hit2D.collider.GetComponent<StartingGround>();
                GroundPrefab groundPrefab = hit2D.collider.GetComponent<GroundPrefab>();
                SpikesPrefab spikesPrefab = hit2D.collider.GetComponent<SpikesPrefab>();
                HealingPrefab healingPrefab = hit2D.collider.GetComponent<HealingPrefab>();
                ShieldPrefab shieldPrefab = hit2D.collider.GetComponent<ShieldPrefab>();

                if (ground != null || groundPrefab != null || spikesPrefab != null || healingPrefab != null || shieldPrefab != null)
                {
                    pos.y = groundHeight;
                    isGrounded = true;
                }
            }
            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red);
        }

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

        distance = pos.x += velocity.x * Time.fixedDeltaTime; //Calcula la distancia que recorrimos

        transform.position = pos;
    }
}
