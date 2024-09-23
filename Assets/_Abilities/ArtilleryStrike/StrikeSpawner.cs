using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeSpawner : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] GameObject Strike;
    [SerializeField] GameObject StrikeMini;
    [SerializeField] GameObject SFX;
    [SerializeField] ability ability;


    public IEnumerator spawnSrikes(float attack, int numberOfStrikes, float attackMini, int numberOfStrikesMini)
    {
        while (true)
        {
            for (int i = 0; i < numberOfStrikes; i++)
            {
                float baseAttack = playerStats.GetAttack();

                Vector3 pos = new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-8f, 8f));

                var wave = Instantiate(Strike, pos, Quaternion.identity);
                StartCoroutine(PlaySFX());
                wave.GetComponentInChildren<WaveAttacks>(true).SetStats(0.01f, (baseAttack * attack) + playerStats.GetAbilityDamage(baseAttack * attack));
                yield return new WaitForSeconds(0.1f);
            }

            if (ability.Evolved)
            {
                for (int i = 0; i < numberOfStrikesMini; i++)
                {
                    float baseAttack = playerStats.GetAttack();

                    Vector3 pos = new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-8f, 8f));

                    var wave = Instantiate(StrikeMini, pos, Quaternion.identity);
                    StartCoroutine(PlaySFX());
                    wave.GetComponentInChildren<WaveAttacks>(true).SetStats((baseAttack * attackMini) + playerStats.GetAbilityDamage(baseAttack * attackMini));
                    yield return new WaitForSeconds(0.1f);
                }
            }

            yield return new WaitForSeconds(playerStats.GetCooldown(5));
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
                StartCoroutine(spawnSrikes(0.75f, 1, 0.25f, 4));
                break;
            case 2:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(0.75f, 2, 0.30f, 6));
                break;
            case 3:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(1f, 3, 0.35f, 8));
                break;
            case 4:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(1f, 4, 0.40f, 10));
                break;
            case 5:
                StopAllCoroutines();
                StartCoroutine(spawnSrikes(1.5f, 5, 0.50f, 12));
                break;
        }
    }
}
