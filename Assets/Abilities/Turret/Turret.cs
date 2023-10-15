using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform Head;
    [SerializeField] BulletMovement bullet;

    Transform target;
    float attack;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (target != null)
            {
                var b = Instantiate(bullet, Head.transform.position, Quaternion.identity);
                b.transform.LookAt(target);
                b.SetAttack(attack);
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
        else
        {
            Head.LookAt(target);
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
