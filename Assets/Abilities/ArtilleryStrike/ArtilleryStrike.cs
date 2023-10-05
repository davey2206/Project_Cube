using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryStrike : MonoBehaviour
{
    [SerializeField] StrikeSpawner strikeSpawner;

    private StrikeSpawner spawner;
    public void Ability(int level, Vector3 pos)
    {
        if (spawner == null)
        {
            spawner = Instantiate(strikeSpawner);
        }

        spawner.Stats(level);
    }
}
