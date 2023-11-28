using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDamage : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] RarityTypes rarity;
    public void Ability(int level, Vector3 pos)
    {
        switch (rarity)
        {
            case RarityTypes.Common:
                playerStats.AbilityDamage = playerStats.AbilityDamage + 1;
                break;
            case RarityTypes.Uncommon:
                playerStats.AbilityDamage = playerStats.AbilityDamage + 2;
                break;
            case RarityTypes.Rare:
                playerStats.AbilityDamage = playerStats.AbilityDamage + 5;
                break;
            case RarityTypes.Epic:
                playerStats.AbilityDamage = playerStats.AbilityDamage + 10;
                break;
            case RarityTypes.Legendary:
                playerStats.AbilityDamage = playerStats.AbilityDamage + 20;
                break;
        }
    }
}
