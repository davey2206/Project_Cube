using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSpawner : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] GameObject Poison;

    public void Stats(int level)
    {
        switch (level)
        {
            case 1:
                StopAllCoroutines();
                StartCoroutine(spawnPoison(0.2f, 1, 0.5f));
                break;
            case 2:
                StopAllCoroutines();
                StartCoroutine(spawnPoison(0.2f, 1, 0.4f));
                break;
            case 3:
                StopAllCoroutines();
                StartCoroutine(spawnPoison(0.2f, 2, 0.3f));
                break;
            case 4:
                StopAllCoroutines();
                StartCoroutine(spawnPoison(0.25f, 2, 0.2f));
                break;
            case 5:
                StopAllCoroutines();
                StartCoroutine(spawnPoison(0.25f, 3, 0.1f));
                break;
        }
    }

    public IEnumerator spawnPoison(float attack, int numberOfStrikes, float attackSpeed)
    {
        while (true)
        {
            for (int i = 0; i < numberOfStrikes; i++)
            {
                float baseAttack = playerStats.GetAttack();

                Vector3 pos = new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-8f, 8f));

                var poison = Instantiate(Poison, pos, Quaternion.identity);
                poison.GetComponent<WaveAttacks>().SetStats((baseAttack * attack) + playerStats.GetAbilityDamage(baseAttack * attack));
                poison.GetComponent<Poison>().SetAttackSpeed(attackSpeed);
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(playerStats.GetCooldown(5));
        }
    }
}
