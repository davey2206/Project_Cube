using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] GameObject Mine;
    [SerializeField] ability ability;

    public IEnumerator spawnSrikes(float attack, int numberOfMines, int extraMines)
    {
        while (true)
        {
            float baseAttack = playerStats.GetAttack() * attack;

            for (int i = 0; i < numberOfMines; i++)
            {
                Vector3 pos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));

                var wave = Instantiate(Mine, pos, Quaternion.identity);
                wave.GetComponentInChildren<WaveAttacks>(true).SetStats(baseAttack + playerStats.GetAbilityDamage(baseAttack));
                yield return new WaitForSeconds(0.1f);
            }

            if (ability.Evolved)
            {
                for (int i = 0; i < extraMines; i++)
                {
                    Vector3 pos = new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-8f, 8f));

                    var wave = Instantiate(Mine, pos, Quaternion.identity);
                    wave.GetComponentInChildren<WaveAttacks>(true).SetStats(baseAttack + playerStats.GetAbilityDamage(baseAttack));
                    yield return new WaitForSeconds(0.1f);
                }
            }

            yield return new WaitForSeconds(playerStats.GetCooldown(10));
        }
    }

    public void Stats(int level)
    {
        switch (level)
        {
            case 1:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(0.5f, 3, 4));
                break;
            case 2:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(0.5f, 4, 5));
                break;
            case 3:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(0.75f, 5, 6));
                break;
            case 4:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(0.75f, 6, 7));
                break;
            case 5:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(1f, 7, 8));
                break;
        }
    }
}
