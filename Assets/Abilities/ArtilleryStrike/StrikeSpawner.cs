using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeSpawner : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] GameObject Strike;

    public IEnumerator spawnSrikes(float attack, int numberOfStrikes)
    {
        while (true)
        {
            for (int i = 0; i < numberOfStrikes; i++)
            {
                float baseAttack = playerStats.GetAttack();

                Vector3 pos = new Vector3(Random.Range(-15, 15), 0, Random.Range(-8, 8));

                var wave = Instantiate(Strike, pos, Quaternion.identity);
                wave.GetComponentInChildren<ArtilleryWave>(true).SetStats(baseAttack * attack);
                yield return new WaitForSeconds(0.1f);
            }
            
            yield return new WaitForSeconds(5);
        }
    }

    public void Stats(int level)
    {
        switch (level)
        {
            case 1:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(0.75f, 1));
                break;
            case 2:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(0.75f, 2));
                break;
            case 3:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(1f, 3));
                break;
            case 4:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(1f, 4));
                break;
            case 5:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(1.5f, 5));
                break;
        }
    }
}
