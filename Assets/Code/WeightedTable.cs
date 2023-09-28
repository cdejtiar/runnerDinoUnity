using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public interface IWeightable
{
    int Weight { get; }
}

public abstract class WeightedTable<T> : ScriptableObject where T : IWeightable
{
    [SerializeField] private List<T> chances;

    public T Evaluate()
    {
        var totalWeight = chances.Select(c => c.Weight).Sum();
        var rolled = Random.Range(0, totalWeight);
        foreach (var chance in chances)
        {
            rolled -= chance.Weight;
            if (rolled < 0)
                return chance;
        }

        throw new System.Exception("Spawn Table failed to select a chance, this shouldn't have happened");
    }
}