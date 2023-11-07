using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritDamage : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] RarityTypes rarity;
    public void Ability(int level, Vector3 pos)
    {
        switch (rarity)
        {
            case RarityTypes.Common:
                playerStats.critDamage = playerStats.critDamage + 10;
                break;
            case RarityTypes.Uncommon:
                playerStats.critDamage = playerStats.critDamage + 15;
                break;
            case RarityTypes.Rare:
                playerStats.critDamage = playerStats.critDamage + 20;
                break;
            case RarityTypes.Epic:
                playerStats.critDamage = playerStats.critDamage + 25;
                break;
            case RarityTypes.Legendary:
                playerStats.critDamage = playerStats.critDamage + 30;
                break;
        }
    }
}
