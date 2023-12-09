using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonField : MonoBehaviour
{
    [SerializeField] PoisonSpawner poisonSpawner;

    private PoisonSpawner spawner;
    public void Ability(int level, Vector3 pos)
    {
        if (spawner == null)
        {
            spawner = Instantiate(poisonSpawner);
        }

        spawner.Stats(level);
    }
}
