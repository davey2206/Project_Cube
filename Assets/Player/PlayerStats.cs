using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public bool alive;
    public float maxHealth;
    public float BaseAttack;
    public float BonusAttack;
    public float AttackSpeed;
    public int Coins;
    public float Luck;

    public float YellowDamage;
    public float BlueDamage;
    public float GreenDamage;

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
