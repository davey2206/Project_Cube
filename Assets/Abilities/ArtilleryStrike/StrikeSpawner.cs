using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeSpawner : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] GameObject Strike;
    [SerializeField] GameObject SFX;

    public IEnumerator spawnSrikes(float attack, int numberOfStrikes)
    {
        while (true)
        {
            for (int i = 0; i < numberOfStrikes; i++)
            {
                float baseAttack = playerStats.GetYellowAttack();

                Vector3 pos = new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-8f, 8f));

                var wave = Instantiate(Strike, pos, Quaternion.identity);
                StartCoroutine(PlaySFX());
                wave.GetComponentInChildren<WaveAttacks>(true).SetStats(baseAttack * attack);
                yield return new WaitForSeconds(0.1f);
            }
            
            yield return new WaitForSeconds(5);
        }
    }

    public IEnumerator PlaySFX()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(SFX, transform.position, Quaternion.identity);
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
