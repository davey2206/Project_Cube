using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] ShieldEffect Shield;
    [SerializeField] ability ability;

    ShieldEffect shieldEffect;
    int MaxNumberOfShields;
    float RegenTime;

    public void Ability(int level, Vector3 pos)
    {
        switch (level)
        {
            case 1:
                shieldEffect = Instantiate(Shield);
                MaxNumberOfShields = 3;
                if (ability.Evolved)
                {
                    MaxNumberOfShields = 4;
                }
                RegenTime = playerStats.GetCooldown(30);
                shieldEffect.LevelUp(MaxNumberOfShields, RegenTime, 1);
                break;
            case 2:
                RegenTime = playerStats.GetCooldown(20);
                if (ability.Evolved)
                {
                    MaxNumberOfShields = 5;
                }
                shieldEffect.LevelUp(MaxNumberOfShields, RegenTime, 2);
                break;
            case 3:
                MaxNumberOfShields = 4;
                if (ability.Evolved)
                {
                    MaxNumberOfShields = 7;
                }
                shieldEffect.LevelUp(MaxNumberOfShields, RegenTime, 3);
                break;
            case 4:
                if (ability.Evolved)
                {
                    MaxNumberOfShields = 8;
                }
                RegenTime = playerStats.GetCooldown(15);
                shieldEffect.LevelUp(MaxNumberOfShields, RegenTime, 4);
                break;
            case 5:
                MaxNumberOfShields = 5;
                if (ability.Evolved)
                {
                    MaxNumberOfShields = 10;
                }
                shieldEffect.LevelUp(MaxNumberOfShields, RegenTime, 5);
                break;
        }
    }
}
