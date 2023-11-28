using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveDeath : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] GameObject bullet;
    int ChangeToExplode;

    public void Ability(int level, Vector3 pos)
    {
        float damage = 0;
        switch (level)
        {
            case 1:
                ChangeToExplode = 25;
                damage = playerStats.GetAttack() * 0.25f;
                spawnBullets(4, pos, damage + playerStats.GetAbilityDamage(damage));
                break;
            case 2:
                ChangeToExplode = 30;
                damage = playerStats.GetAttack() * 0.5f;
                spawnBullets(4, pos, damage + playerStats.GetAbilityDamage(damage));
                break;
            case 3:
                ChangeToExplode = 35;
                damage = playerStats.GetAttack() * 0.75f;
                spawnBullets(6, pos, damage + playerStats.GetAbilityDamage(damage));
                break;
            case 4:
                ChangeToExplode = 40;
                damage = playerStats.GetAttack();
                spawnBullets(6, pos, damage + playerStats.GetAbilityDamage(damage));
                break;
            case 5:
                ChangeToExplode = 50;
                damage = playerStats.GetAttack();
                spawnBullets(8, pos, damage + playerStats.GetAbilityDamage(damage));
                break;
        }
    }

    void spawnBullets(int numberOfBullets, Vector3 pos, float attack)
    {
        if (Random.Range(0, 101) <= ChangeToExplode + playerStats.Luck)
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
