using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveClick : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] WaveAttacks Wave;
    [SerializeField] ability ability;

    int counter = 0;
    float oldAttackSpeedBonus = 0;

    public void Ability(int level, Vector3 pos)
    {
        float damage = 0;
        WaveAttacks wave;

        switch (level)
        {
            case 1:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                damage = playerStats.GetAttack() * 0.25f;
                wave.SetStats(damage + playerStats.GetAbilityDamage(damage), 3, true);
                if (ability.Evolved && counter != 1)
                {
                    counter = 1;
                    playerStats.AttackSpeed += 0.25f;
                    oldAttackSpeedBonus = 0.25f;
                }
                break;
            case 2:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                damage = playerStats.GetAttack() * 0.25f;
                wave.SetStats(damage + playerStats.GetAbilityDamage(damage), 5, true);
                if (ability.Evolved && counter != 2)
                {
                    counter = 2;
                    playerStats.AttackSpeed -= oldAttackSpeedBonus;
                    playerStats.AttackSpeed += 0.50f;
                    oldAttackSpeedBonus = 0.50f;
                }
                break;
            case 3:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                damage = playerStats.GetAttack() * 0.50f;
                wave.SetStats(damage + playerStats.GetAbilityDamage(damage), 5, true);
                if (ability.Evolved && counter != 3)
                {
                    counter = 3;
                    playerStats.AttackSpeed -= oldAttackSpeedBonus;
                    playerStats.AttackSpeed += 0.75f;
                    oldAttackSpeedBonus = 0.75f;
                }
                break;
            case 4:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                damage = playerStats.GetAttack() * 0.50f;
                wave.SetStats(damage + playerStats.GetAbilityDamage(damage), 8, true);
                if (ability.Evolved && counter != 4)
                {
                    counter = 4;
                    playerStats.AttackSpeed -= oldAttackSpeedBonus;
                    playerStats.AttackSpeed += 1.00f;
                    oldAttackSpeedBonus = 1.00f;
                }
                break;
            case 5:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                damage = playerStats.GetAttack() * 0.75f;
                wave.SetStats(damage + playerStats.GetAbilityDamage(damage), 8, true);
                if (ability.Evolved && counter != 5)
                {
                    counter = 5;
                    playerStats.AttackSpeed -= oldAttackSpeedBonus;
                    playerStats.AttackSpeed += 1.25f;
                    oldAttackSpeedBonus = 1.25f;
                }
                break;
        }
    }
}
