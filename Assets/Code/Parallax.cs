using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public Transform target;
    public float speed = 1f;
    private float startPosition;
    private float length;

    void Start()
    {
        startPosition = transform.position.x;
        length = spriteRenderer.bounds.size.x;
    }

    void FixedUpdate()
    {
        var dist = target.position.x * speed;

        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);

        var relativeCameraDist = target.position.x * (1 - speed);
        if (relativeCameraDist > startPosition + length)
            startPosition += length;
        else if (relativeCameraDist < startPosition - length)
            startPosition -= length;
    }
}
