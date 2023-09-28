using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] MetaStats metaStats;
    public float maxHealth;
    public float BaseAttack;
    public float BonusAttack;
    public int Coins;
    public float Luck;

    public float GetAttack()
    {
        float attack = BaseAttack + (BaseAttack * BonusAttack);

        return attack;
    }

    public void AddBonusAttack(float attackBonus)
    {
        BonusAttack = BonusAttack + attackBonus;
    }

    public void ResetStats()
    {
        BonusAttack = metaStats.BonusAttack;
        Luck = metaStats.Luck;
        Coins = 0;
    }

    public void AddCoins()
    {
        metaStats.Coins += Coins;
    }
}
