using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Wave Wave;
    [SerializeField] ability ability;

    public IEnumerator spawnWave(float stunTime, float attack, float spawnDelay, float bonusAttack)
    {
        while (true)
        {
            float baseAttack = playerStats.GetAttack() * attack;
            var wave = Instantiate(Wave, Vector3.zero, Quaternion.identity);
            wave.SetStats(stunTime, baseAttack + playerStats.GetAbilityDamage(baseAttack));

            if (ability.Evolved)
            {
                baseAttack = playerStats.GetAttack() * bonusAttack;
                var waveDamage = Instantiate(Wave, Vector3.zero, Quaternion.identity);
                waveDamage.SetStats(0, baseAttack + playerStats.GetAbilityDamage(baseAttack));
            }

            yield return new WaitForSeconds(playerStats.GetCooldown(spawnDelay));
        }
    }

    public void Stats(int level)
    {
        switch (level)
        {
            case 1:
                StopAllCoroutines();
                StartCoroutine(spawnWave(0.5f, 0, 10, 0.20f));
                break;
            case 2:
                StopAllCoroutines();
                StartCoroutine(spawnWave(0.75f, 0, 8, 0.40f));
                break;
            case 3:
                StopAllCoroutines();
                StartCoroutine(spawnWave(1f, 0, 7, 0.60f));
                break;
            case 4:
                StopAllCoroutines();
                StartCoroutine(spawnWave(1.25f, 0, 6, 0.80f));
                break;
            case 5:
                StopAllCoroutines();
                StartCoroutine(spawnWave(1.5f, 0.20f, 5, 1f));
                break;
        }
    }
}
