using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] GameObject Mine;

    public IEnumerator spawnSrikes(float attack, int numberOfStrikes)
    {
        while (true)
        {
            for (int i = 0; i < numberOfStrikes; i++)
            {
                float baseAttack = playerStats.GetAttack();

                Vector3 pos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));

                var wave = Instantiate(Mine, pos, Quaternion.identity);
                wave.GetComponentInChildren<WaveAttacks>(true).SetStats(baseAttack * attack);
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(10);
        }
    }

    public void Stats(int level)
    {
        switch (level)
        {
            case 1:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(0.5f, 3));
                break;
            case 2:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(0.5f, 4));
                break;
            case 3:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(0.75f, 5));
                break;
            case 4:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(0.75f, 6));
                break;
            case 5:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(1f, 7));
                break;
        }
    }
}
