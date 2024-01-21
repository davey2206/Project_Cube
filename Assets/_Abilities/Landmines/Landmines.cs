using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmines : MonoBehaviour
{
    [SerializeField] MineSpawner mineSpawner;

    private MineSpawner spawner;
    public void Ability(int level, Vector3 pos)
    {
        if (spawner == null)
        {
            spawner = Instantiate(mineSpawner);
        }

        spawner.Stats(level);
    }
}
