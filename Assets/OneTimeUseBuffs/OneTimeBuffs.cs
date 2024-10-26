using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buff", menuName = "ScriptableObjects/OneTimeBuff")]
public class OneTimeBuffs : ScriptableObject
{
    [SerializeField] public Material Mat;
    [SerializeField] StatType Stat;
    [SerializeField] float amount;

    public float GainStat(StatType stat)
    {
        if (stat == Stat)
        {
            return amount;
        }

        return 0;
    }
}

public enum StatType
{
    BaseAttack,
    BonusAttack,
    Luck,
    AttackSpeed,
    critRate,
    critDamage,
    AbilityDamage,
    AbilityCooldown,
    maxHealth
}
