using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("SaveFile")]
    [SerializeField] SaveFile saveFile;

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
        BonusAttack = 0 + saveFile.BonusAttack;
        Luck = 0 + saveFile.Luck;
        AttackSpeed = 4 + saveFile.AttackSpeed;
        critRate = 1 + saveFile.critRate;
        critDamage = 50 + saveFile.critDamage;
        AbilityDamage = 0 + saveFile.AbilityDamage;
        AbilityCooldown = 0 + saveFile.AbilityCooldown;
        maxHealth = 10 + saveFile.maxHealth;
        Coins = 0;
        Shields = 0;
    }

    public void AddCoins()
    {
        saveFile.coins += Coins;
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
