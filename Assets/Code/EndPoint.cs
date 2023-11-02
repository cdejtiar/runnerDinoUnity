using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private GameObject winnerPrefab;
    [SerializeField] private Transform canvasTransform;

    //private bool hasWinnerBeenCalled = false; // Variable para controlar si Winner se ha llamado

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            Instantiate(winnerPrefab, canvasTransform);
            Time.timeScale = 0;
            //hasWinnerBeenCalled = true; // Marca que Winner se ha llamado
        }
    }
}