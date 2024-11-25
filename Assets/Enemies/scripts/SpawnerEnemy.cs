using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : Enemy
{
    [Header("Spawner")]
    [SerializeField] ArmSpawner Spawner;
    [SerializeField] GameObject Effect;

    bool spawning = false;

    public override void Move()
    {
        if (!isDead && !Stunned && Vector3.Distance(Vector3.zero, transform.position) > 9f)
        {
            var step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, step);
        }
        else if (!isDead && !spawning)
        {
            spawning = true;
            StartSpwaning();
        }
    }

    public void StartSpwaning()
    {
        Effect.SetActive(true);
        Spawner.StartSpawning();
    }
}
