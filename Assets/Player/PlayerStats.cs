using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float maxHealth;
    public float BaseAttack;
    public float BonusAttack;

    public float GetAttack()
    {
        float attack = BaseAttack + (BaseAttack * BonusAttack);

        return attack;
    }

    public void AddBonusAttack(float attackBonus)
    {
        BonusAttack = BonusAttack + attackBonus;
    }
}
