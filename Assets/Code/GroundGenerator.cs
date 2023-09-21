using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private int xMin;
    [SerializeField] private int xMax;

    [SerializeField] private GameObject groundPrefab;

    void Start()
    {
        for (int x = xMin; x < xMax; x++)
        {
            CreateGround(x);
        }
    }

    private void CreateGround(int x)
    {
        GameObject groundGo = Instantiate(groundPrefab, transform);
        groundGo.transform.position = new Vector2(x, 0);
    }
}
