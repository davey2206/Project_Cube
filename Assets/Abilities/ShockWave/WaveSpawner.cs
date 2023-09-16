using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Wave Wave;

    public IEnumerator spawnWave(float stunTime, float attack, float spawnDelay)
    {
        while (true)
        {
            float baseAttack = playerStats.GetAttack();
            var wave = Instantiate(Wave, Vector3.zero, Quaternion.identity);
            wave.SetStats(stunTime, baseAttack * attack);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void Stats(int level)
    {
        switch (level)
        {
            case 1:
                StopAllCoroutines();
                StartCoroutine(spawnWave(0.5f, 0, 10));
                break;
            case 2:
                StopAllCoroutines();
                StartCoroutine(spawnWave(0.75f, 0, 8));
                break;
            case 3:
                StopAllCoroutines();
                StartCoroutine(spawnWave(1f, 0, 7));
                break;
            case 4:
                StopAllCoroutines();
                StartCoroutine(spawnWave(1.25f, 0, 6));
                break;
            case 5:
                StopAllCoroutines();
                StartCoroutine(spawnWave(1.5f, 0.25f, 5));
                break;
        }
    }
}
