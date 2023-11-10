using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowDamageBoost : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] RarityTypes rarity;
    public void Ability(int level, Vector3 pos)
    {
        switch (rarity)
        {
            case RarityTypes.Common:
                playerStats.YellowDamage = playerStats.YellowDamage + 5;
                break;
            case RarityTypes.Uncommon:
                playerStats.YellowDamage = playerStats.YellowDamage + 10;
                break;
            case RarityTypes.Rare:
                playerStats.YellowDamage = playerStats.YellowDamage + 15;
                break;
            case RarityTypes.Epic:
                playerStats.YellowDamage = playerStats.YellowDamage + 20;
                break;
            case RarityTypes.Legendary:
                playerStats.YellowDamage = playerStats.YellowDamage + 25;
                break;
        }
    }
}
