using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDamageBoost : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] RarityTypes rarity;
    public void Ability(int level, Vector3 pos)
    {
        switch (rarity)
        {
            case RarityTypes.Common:
                playerStats.BlueDamage = playerStats.BlueDamage + 5;
                break;
            case RarityTypes.Uncommon:
                playerStats.BlueDamage = playerStats.BlueDamage + 10;
                break;
            case RarityTypes.Rare:
                playerStats.BlueDamage = playerStats.BlueDamage + 15;
                break;
            case RarityTypes.Epic:
                playerStats.BlueDamage = playerStats.BlueDamage + 20;
                break;
            case RarityTypes.Legendary:
                playerStats.BlueDamage = playerStats.BlueDamage + 25;
                break;
        }
    }
}
