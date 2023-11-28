using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCooldown : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] RarityTypes rarity;
    public void Ability(int level, Vector3 pos)
    {
        switch (rarity)
        {
            case RarityTypes.Common:
                playerStats.AbilityCooldown = playerStats.AbilityCooldown + 1;
                break;
            case RarityTypes.Uncommon:
                playerStats.AbilityCooldown = playerStats.AbilityCooldown + 2;
                break;
            case RarityTypes.Rare:
                playerStats.AbilityCooldown = playerStats.AbilityCooldown + 5;
                break;
            case RarityTypes.Epic:
                playerStats.AbilityCooldown = playerStats.AbilityCooldown + 10;
                break;
            case RarityTypes.Legendary:
                playerStats.AbilityCooldown = playerStats.AbilityCooldown + 20;
                break;
        }
    }
}
