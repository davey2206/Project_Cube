using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ExplosiveDeath : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] GameObject bullet;
    int ChangeToExplode;

    public void Ability(int level, Vector3 pos)
    {
        float baseAttack = playerStats.GetAttack();
        switch (level)
        {
            case 1:
                ChangeToExplode = 25;
                spawnBullets(4, pos, baseAttack * 0.5f);
                break;
            case 2:
                ChangeToExplode = 30;
                spawnBullets(4, pos, baseAttack * 1f);
                break;
            case 3:
                ChangeToExplode = 35;
                spawnBullets(6, pos, baseAttack * 1f);
                break;
            case 4:
                ChangeToExplode = 40;
                spawnBullets(6, pos, baseAttack * 1.5f);
                break;
            case 5:
                ChangeToExplode = 50;
                spawnBullets(8, pos, baseAttack * 1.5f);
                break;
        }
    }

    void spawnBullets(int numberOfBullets, Vector3 pos, float attack)
    {
        if (Random.Range(0, 101) <= ChangeToExplode)
        {
            float dir = 360 / numberOfBullets;
            float rot = 0;
            for (int i = 0; i < numberOfBullets; i++)
            {
                var b = Instantiate(bullet, new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(0, rot, 0));
                b.GetComponent<BulletMovement>().SetAttack(attack);
                rot = rot + dir;
            }
        }
    }
}
