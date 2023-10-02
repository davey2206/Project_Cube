using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float maxHealth;
    public float BaseAttack;
    public float BonusAttack;
    public float AttackSpeed;
    public int Coins;
    public float Luck;

    public float GetAttack()
    {
        float attack = BaseAttack + (BaseAttack * (BonusAttack / 100));

        return attack;
    }

    public void AddBonusAttack(float attackBonus)
    {
        BonusAttack = BonusAttack + attackBonus;
    }

    public void ResetStats()
    {
        BonusAttack = MetaProgression.GetAttackBonus();
        Luck = MetaProgression.GetLuckBonus();
        AttackSpeed = 3 + MetaProgression.GetAttackSpeedBonus();
        Coins = 0;
    }

    public void AddCoins()
    {
        MetaProgression.SaveCoins(MetaProgression.GetCoins() + Coins);
    }

    public float GetAttackSpeed()
    {
        return 1 / (AttackSpeed);
    }
}
