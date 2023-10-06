using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStorm : MonoBehaviour
{
    [SerializeField] BulletStormSpawner bulletStormSpawner;

    private BulletStormSpawner spawner;
    public void Ability(int level, Vector3 pos)
    {
        if (spawner == null)
        {
            spawner = Instantiate(bulletStormSpawner);
        }

        spawner.Stats(level);
    }
}
