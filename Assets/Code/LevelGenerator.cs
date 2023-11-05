using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private ObstaclesTable obstaclesTable;
    [SerializeField] private PlayerMove player;

    [SerializeField] private GroundPrefab groundPrefab;
    private float xMax = 10;

    private float posXsave = 0;

    void Start()
    {
        Vector2 pos = player.transform.position;
        posXsave = pos.x;
        // crea 20 obstaculos
        // los primeros 5 o 10 son pasto
        // los otros random
        if (pos.x == -10f)
        {

            for (float x = pos.x; x < xMax; x++)
            {
                CreateInicialGround(x);
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
        for (float x = posXsave; x < posXsave + xMax; x++)
        {
            CreateObstacle(x + 20.0f);
        }
    }
    void FixedUpdate()
    {
        Vector2 pos = player.transform.position;

        float xPosDiff = pos.x - posXsave;

        if (xPosDiff >= 10.0f)
        {
            GenerateObstacles();

            posXsave = pos.x;
        }
        // cada 10 en la player.transform.position.x
        // creo una tanda mas de obstaculos (por ej, 10)
    }
}
