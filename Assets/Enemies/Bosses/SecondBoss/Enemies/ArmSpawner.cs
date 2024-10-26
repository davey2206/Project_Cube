using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSpawner : MonoBehaviour
{
    [SerializeField] List<Transform> SpawnPoints;
    [SerializeField] GameObject Enemy;
    [SerializeField] float spawnDelay = 1.3f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            foreach (var SpawnPoint in SpawnPoints)
            {
                Instantiate(Enemy, SpawnPoint.position, Quaternion.Euler(20, 0, 20));
                yield return new WaitForSeconds(spawnDelay);
            }

            spawnDelay -= 0.1f;

            if (spawnDelay <= 0.3f)
            {
                spawnDelay = 0.3f;
            }
        }
    }
}
