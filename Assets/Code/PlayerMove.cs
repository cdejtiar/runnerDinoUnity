using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb; //Declaro
    [SerializeField] private float speed = 4;
    [SerializeField] private SpriteRenderer spriteRenderer;
    void OnMove(InputValue value)
    {
        var direction = value.Get<Vector2>();
        rb.velocity = direction * speed;

        if (direction.x != 0)
        {
            spriteRenderer.flipX = direction.x < 0;
        }
    }
}
