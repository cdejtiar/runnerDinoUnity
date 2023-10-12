using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float depth = 1; //Es como el posicionamiento en las capas (Z-Index)

    [SerializeField] private PlayerMove player; //Estos los ponemos como Serialized para no tener que inicializarlos con el GetComponent.

    void fixedUpdate()
    {
        //float realVelocity = player.velocity.x / depth; //Le bajo la velocidad dependiendo de lo que se mueva el player y del depth que tenga
        Vector2 pos = transform.position;

        //pos.x -= realVelocity * Time.fixedDeltaTime; //Calculo como voy a moverlo

        if (pos.x <= -13f)
        { //Calcular cuando se va de pantalla
            pos.x = 13f; //Ponerlo donde debería regresar a la pantalla
        }

        transform.position = pos; //Lo muevo
    }
}
