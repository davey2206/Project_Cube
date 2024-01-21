using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    [SerializeField] WaveSpawner waveSpawner;

    private WaveSpawner spawner;
    public void Ability(int level, Vector3 pos)
    {
        if (spawner == null)
        {
            spawner = Instantiate(waveSpawner);
        }

        spawner.Stats(level);
    }
}
