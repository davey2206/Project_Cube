using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunTurret : MonoBehaviour
{
    [SerializeField] Transform Head;
    [SerializeField] BulletMovement bullet;

    Transform target;
    float attack;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            int y = 0;
            GetComponent<Animator>().SetTrigger("Fire");
            yield return new WaitForSeconds(0.2f);
            for (int i = 0; i < 15; i++)
            {
                if (target != null)
                {
                    var b = Instantiate(bullet, Head.GetChild(y).transform.position, Quaternion.identity);

                    float accuracy = (Vector3.Distance(transform.position, target.position) / 5) + 1;
                    Vector3 pos = target.position;
                    pos += transform.forward * Random.Range(-accuracy, accuracy);

                    b.transform.LookAt(pos);
                    b.SetAttack(attack);
                    yield return new WaitForSeconds(0.1f);
                    y++;
                    if (y == 4)
                    {
                        y = 0;
                    }
                }
            }
            
        }
    }

    private void Update()
    {
        if (target == null)
        {
            List<Transform> enemies = new List<Transform>();
            foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemies.Add(enemy.transform);
            }

            foreach (var enemy in GameObject.FindGameObjectsWithTag("Boss"))
            {
                enemies.Add(enemy.transform);
            }

            target = GetClosestEnemy(enemies);
        }
    }

    Transform GetClosestEnemy(List<Transform> enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }

    public void Stats(float LifeSpan, float a)
    {
        attack = a;
        StartCoroutine(DeSpawn(LifeSpan));
    }

    IEnumerator DeSpawn(float LifeSpan)
    {
        yield return new WaitForSeconds(LifeSpan);
        GetComponent<Animator>().SetTrigger("DeSpawn");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
