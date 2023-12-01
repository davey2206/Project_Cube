using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoost : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] RarityTypes rarity;
    public void Ability(int level, Vector3 pos)
    {
        switch (rarity)
        {
            case RarityTypes.Common:
                playerStats.BonusAttack = playerStats.BonusAttack + 10;
                break;
            case RarityTypes.Uncommon:
                playerStats.BonusAttack = playerStats.BonusAttack + 20;
                break;
            case RarityTypes.Rare:
                playerStats.BonusAttack = playerStats.BonusAttack + 30;
                break;
            case RarityTypes.Epic:
                playerStats.BonusAttack = playerStats.BonusAttack + 50;
                break;
            case RarityTypes.Legendary:
                playerStats.BonusAttack = playerStats.BonusAttack + 100;
                break;
        }
    }
}
