using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesGenerator : MonoBehaviour
{

    [SerializeField] private float xMin;
    [SerializeField] private float xMax;

    //[SerializeField] private GameObject spikesPrefab;
    [SerializeField] private ObstaclesTable obstaclesTable;

    //[SerializeField] private float spikesChance = 1;

    void Start()
    {
        for (float x = xMin; x < xMax; x++)
        {
            //if (myRandom.RandomBool(spikesChance))
            //{
                CreateObstacle(x);
            //}
        }
    }

    private void CreateObstacle(float x)
    {
        var obstacle = obstaclesTable.Evaluate();

        GameObject obstacleGo = Instantiate(obstacle.Prefab, transform);
        obstacleGo.transform.position = new Vector2(x, -4.5f);
    }
}