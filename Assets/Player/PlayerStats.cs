using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public bool alive;
    public int Coins;
    
    [Header("Stats")]
    public float Luck;
    public float maxHealth;
    public float AttackSpeed;

    [Header("Crit")]
    public float critRate;
    public float critDamage;

    [Header("Damage")]
    public float BaseAttack;
    public float YellowDamage;
    public float BlueDamage;
    public float GreenDamage;


    [Header("DamageBonus")]
    public float BonusAttack;
    public float YellowDamageBonus;
    public float BlueDamageBonus;
    public float GreenDamageBonus;

    public float GetAttack()
    {
        float attack = BaseAttack + (BaseAttack * (BonusAttack / 100));

        return attack;
    }

    public float GetYellowAttack()
    {
        float attack = BaseAttack + (BaseAttack * (BonusAttack / 100));

        attack = attack + (attack * ((YellowDamage + YellowDamageBonus) / 100));

        return attack;
    }

    public float GetBlueAttack()
    {
        float attack = BaseAttack + (BaseAttack * (BonusAttack / 100));

        attack = attack + (attack * ((BlueDamage + BlueDamageBonus) / 100));

        return attack;
    }

    public float GetGreenAttack()
    {
        float attack = BaseAttack + (BaseAttack * (BonusAttack / 100));

        attack = attack + (attack * ((GreenDamage + GreenDamageBonus) / 100));

        return attack;
    }

    public void AddBonusAttack(float attackBonus)
    {
        BonusAttack = BonusAttack + attackBonus;
    }

    public void ResetStats()
    {
        alive = true;
        BonusAttack = MetaProgression.GetAttackBonus();
        Luck = MetaProgression.GetLuckBonus();
        AttackSpeed = 3 + MetaProgression.GetAttackSpeedBonus();
        YellowDamage = MetaProgression.GetYellowDamageBonus();
        BlueDamage = MetaProgression.GetBlueDamageBonus();
        GreenDamage = MetaProgression.GetGreenDamageBonus();
        critRate = 1 + MetaProgression.GetCritRateBonus();
        critDamage = 50 + MetaProgression.GetCritDamageBonus();
        maxHealth = 10;
        Coins = 0;
    }

    public void AddCoins()
    {
        int coins = MetaProgression.GetCoins() + Coins;
        MetaProgression.SaveCoins(coins);
    }

    public float GetAttackSpeed()
    {
        return 1 / (AttackSpeed);
    }

    public bool crit()
    {
        if (critRate >= Random.Range(0, 101))
        {
            return true;
        }
        return false;
    }

    public float GetCritDamage(float damage)
    {
        return damage + (damage * (critDamage / 100));
    }
}
