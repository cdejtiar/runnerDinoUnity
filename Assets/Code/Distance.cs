using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    [SerializeField] private PlayerMove player; // Acceder al script PlayerMove
    [SerializeField] private TextMeshProUGUI distanceText;
    public float currentDistance;

    void Update()
    {
        if (player != null)
        {
            int distanceInt = Mathf.FloorToInt(player.Distance); //Calculo la distancia y la redondeo para un int
            currentDistance = distanceInt;
            distanceText.text = distanceInt + " m"; //Pongo la distancia cada vez que se actualiza
        }
    }
    /*[SerializeField] private GameObject player; //PREGUNTAR!!! No nos funciono con el serializeField para inicializarlo desde Unity Editor.
    [SerializeField] private GameObject distanceText; //Estos los ponemos como Serialized para no tener que inicializarlos con el GetComponent.

    void Update()
    {
        int distance = Mathf.FloorToInt(player.distance); //Calculo la distancia y la redondeo para un int
        distanceText.text = distance + " m"; //Pongo la distancia cada vez que se actualiza
    }*/
}
