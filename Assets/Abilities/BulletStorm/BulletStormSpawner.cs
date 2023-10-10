using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStormSpawner : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] BulletMovement Bullet;


    public IEnumerator spawnBullet(float attack, int numberOfBullets)
    {
        while (true)
        {
            float dir = 360 / 20;
            float rot = 0;
            for (int i = 0; i < numberOfBullets; i++)
            {
                float baseAttack = playerStats.GetYellowAttack();
                var b = Instantiate(Bullet, Vector3.zero, Quaternion.Euler(0, rot, 0));
                b.SetAttack(baseAttack * attack);
                rot = rot + dir;
                yield return new WaitForSeconds(0.01f);
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
                StartCoroutine(spawnBullet(0.5f, 20));
                break;
            case 2:
                StopAllCoroutines();
                StartCoroutine(spawnBullet(0.5f, 30));
                break;
            case 3:
                StopAllCoroutines();
                StartCoroutine(spawnBullet(0.5f, 40));
                break;
            case 4:
                StopAllCoroutines();
                StartCoroutine(spawnBullet(0.5f, 50));
                break;
            case 5:
                StopAllCoroutines();
                StartCoroutine(spawnBullet(0.5f, 60));
                break;
        }
    }
}
