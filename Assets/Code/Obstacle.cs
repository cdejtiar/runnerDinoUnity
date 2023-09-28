using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle", menuName = "runnerDino/Obstacle", order = 0)]

public class Obstacle : ScriptableObject, IWeightable
{
    [SerializeField] private int damage = 25;
    [SerializeField] private string obstacleName;
    [SerializeField] private GameObject prefab;
    [SerializeField] int weight;

    public int Damage => damage;
    public int Weight => weight;
    public GameObject Prefab => prefab;
}