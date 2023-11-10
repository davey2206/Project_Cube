using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDamageBoost : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] RarityTypes rarity;
    public void Ability(int level, Vector3 pos)
    {
        switch (rarity)
        {
            case RarityTypes.Common:
                playerStats.GreenDamage = playerStats.GreenDamage + 5;
                break;
            case RarityTypes.Uncommon:
                playerStats.GreenDamage = playerStats.GreenDamage + 10;
                break;
            case RarityTypes.Rare:
                playerStats.GreenDamage = playerStats.GreenDamage + 15;
                break;
            case RarityTypes.Epic:
                playerStats.GreenDamage = playerStats.GreenDamage + 20;
                break;
            case RarityTypes.Legendary:
                playerStats.GreenDamage = playerStats.GreenDamage + 25;
                break;
        }
    }
}
