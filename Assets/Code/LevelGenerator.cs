using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float TILE_HEIGHT = -4.5f;
    [SerializeField] private ObstaclesTable obstaclesTable;
    [SerializeField] private PlayerMove player;

    [SerializeField] private GroundPrefab groundPrefab;
    private float batch = 20f; //largo de cada tanda

    private float playerPosXsave = 0f; //guarda la posicion del jugador en cada batch

    private float obstaclePosXsave = 0f; //guarda la posicion del ultimo obstaculo generado en cada batch



    void Start()
    {
        Vector2 pos = player.transform.position;
        playerPosXsave = pos.x;

        if (pos.x == -10f)
        {
            for (float x = pos.x; x < batch; x++)
            {
                CreateObstacle(x, false);
            }
            obstaclePosXsave = batch - 1;
        }
    }

    private void CreateObstacle(float x, bool isObstacle)
    {

        if (isObstacle)
        {
            var obstacle = obstaclesTable.Evaluate();
            GameObject gameObject = Instantiate(obstacle.Prefab, transform);
            gameObject.transform.position = new Vector2(x, TILE_HEIGHT);
        }
        else
        {
            var ground = Instantiate(groundPrefab, transform);
            ground.transform.position = new Vector2(x, TILE_HEIGHT);
        }


    }
    private void GenerateObstacles()
    {
        for (float x = obstaclePosXsave; x < obstaclePosXsave + batch; x++)
        {
            CreateObstacle(x, true);
        }
        obstaclePosXsave = obstaclePosXsave + batch - 1;
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
    }
}
