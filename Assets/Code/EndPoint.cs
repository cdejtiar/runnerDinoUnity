using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private GameObject winnerPrefab;
    [SerializeField] private Transform canvasTransform;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            Instantiate(winnerPrefab, canvasTransform);
            Time.timeScale = 0;
        }
    }
}