using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private ObstaclesTable obstaclesTable;
    [SerializeField] private PlayerMove player;

    [SerializeField] private GroundPrefab groundPrefab;
    private float xMax = 10;

    private float playerPosXsave = 0;

    private float obstaclePosXsave = 0;


    void Start()
    {
        Vector2 pos = player.transform.position;
        playerPosXsave = pos.x;
        // crea 20 obstaculos
        // los primeros 5 o 10 son pasto
        // los otros random
        if (pos.x == -10f)
        {
            for (float x = pos.x; x < xMax; x++)
            {
                CreateInicialGround(x);
                obstaclePosXsave = x;
                Debug.Log(x);
            }
        }
    }

    private void CreateInicialGround(float x)
    {
        var ground = Instantiate(groundPrefab, transform);
        ground.transform.position = new Vector2(x, -4.5f);
    }

    private void CreateObstacle(float x)
    {
        var obstacle = obstaclesTable.Evaluate();

        GameObject obstacleGo = Instantiate(obstacle.Prefab, transform);
        obstacleGo.transform.position = new Vector2(x, -4.5f);
    }
    private void GenerateObstacles()
    {
        if (obstaclePosXsave >= 9f)
        {
            for (float x = obstaclePosXsave; x < playerPosXsave + xMax; x++)
            {
                CreateObstacle(x + 30f);
                obstaclePosXsave = x;
            }
        }
        /*else if (obstaclePosXsave == 9f)
        {
            for (float x = obstaclePosXsave; x < playerPosXsave + xMax; x++)
            {
                CreateObstacle(x);
            }
        }*/

    }
    void FixedUpdate()
    {
        Vector2 pos = player.transform.position;

        float xPosDiff = pos.x - playerPosXsave;

        if (xPosDiff >= 10.0f)
        {
            GenerateObstacles();

            playerPosXsave = pos.x;
        }
        // cada 10 en la player.transform.position.x
        // creo una tanda mas de obstaculos (por ej, 10)
    }
}
