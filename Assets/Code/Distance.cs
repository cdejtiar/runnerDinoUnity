using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    [SerializeField] private PlayerMove player; // Acceder al script PlayerMove
    [SerializeField] private TextMeshProUGUI distanceText;
    private int currentDistance;

    public int CurrentDistance => currentDistance;

    void Update() //hacer corrutina de 1s (probar)
    {
        if (player != null) //probar sacar el if
        {
            int distanceInt = Mathf.FloorToInt(player.Distance + 10); //Calculo la distancia y la redondeo para un int, +10 porque la pos.x empieza en -10, ¡preguntar para no forzarlo!
            currentDistance = distanceInt;
            distanceText.text = distanceInt + " m"; //Pongo la distancia cada vez que se actualiza
            ScoreManager.Instance.ActualScore = currentDistance;
        }
    }
}