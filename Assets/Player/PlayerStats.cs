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
    public float BonusAttack;

    [Header("Ability")]
    public float AbilityDamage;
    public float AbilityCooldown;

    [Header("Shield")]
    [Range(0,5)]
    public int Shields;

    public float GetAttack()
    {
        float attack = BaseAttack + (BaseAttack * (BonusAttack / 100));

        return attack;
    }

    public void AddBonusAttack(float attackBonus)
    {
        BonusAttack = BonusAttack + attackBonus;
    }

    public float GetAbilityDamage(float Damage)
    {
        float d = Damage * (AbilityDamage / 100);

        return d;
    }

    public void ResetStats()
    {
        alive = true;
        BaseAttack = 0.5f;
        BonusAttack = 0 + MetaProgression.GetAttackBonus();
        Luck = 0 + MetaProgression.GetLuckBonus();
        AttackSpeed = 3 + MetaProgression.GetAttackSpeedBonus();
        critRate = 1 + MetaProgression.GetCritRateBonus();
        critDamage = 50 + MetaProgression.GetCritDamageBonus();
        AbilityDamage = 0 + MetaProgression.GetAbilityDamageBonus();
        AbilityCooldown = 0 + MetaProgression.GetAbilityCooldownBonus();
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

    public float GetCooldown(float time)
    {
        float cooldown = time;

        if (AbilityCooldown != 0)
        {
            cooldown = time * (100 / (100 + AbilityCooldown));
        }

        return cooldown;
    }
}
