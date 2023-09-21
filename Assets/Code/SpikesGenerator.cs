using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesGenerator : MonoBehaviour
{

    [SerializeField] private int xMin;
    [SerializeField] private int xMax;

    [SerializeField] private GameObject spikesPrefab;

    [SerializeField] private float spikesChance = 1;

    void Start()
    {
        for (int x = xMin; x < xMax; x+=2)
        {
            if (myRandom.RandomBool(spikesChance))
            {
                CreateSpike(x);
            }
        }
    }

    private void CreateSpike(int x)
    {
        GameObject spikesGo = Instantiate(spikesPrefab, transform);
        spikesGo.transform.position = new Vector2(x, 0);
    }
}