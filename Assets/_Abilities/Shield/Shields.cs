using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] ShieldEffect Shield;

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
                RegenTime = playerStats.GetCooldown(30);
                shieldEffect.LevelUp(MaxNumberOfShields, RegenTime);
                break;
            case 2:
                RegenTime = playerStats.GetCooldown(20);
                shieldEffect.LevelUp(MaxNumberOfShields, RegenTime);
                break;
            case 3:
                MaxNumberOfShields = 4;
                shieldEffect.LevelUp(MaxNumberOfShields, RegenTime);
                break;
            case 4:
                RegenTime = playerStats.GetCooldown(15);
                shieldEffect.LevelUp(MaxNumberOfShields, RegenTime);
                break;
            case 5:
                MaxNumberOfShields = 5;
                shieldEffect.LevelUp(MaxNumberOfShields, RegenTime);
                break;
        }
    }
}
