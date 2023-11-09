using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    [SerializeField] private PlayerMove player; // Acceder al script PlayerMove
    [SerializeField] private TextMeshProUGUI distanceText;
    public int currentDistance;

    void Update()
    {
        if (player != null)
        {
            int distanceInt = Mathf.FloorToInt(player.Distance + 10); //Calculo la distancia y la redondeo para un int, +10 porque la pos.x empieza en -10, ¡preguntar para no forzarlo!
            currentDistance = distanceInt;
            distanceText.text = distanceInt + " m"; //Pongo la distancia cada vez que se actualiza
        }
    }


}