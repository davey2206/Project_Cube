using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealth : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] RarityTypes rarity;
    public void Ability(int level, Vector3 pos)
    {
        switch (rarity)
        {
            case RarityTypes.Rare:
                playerStats.maxHealth = playerStats.maxHealth + 1;
                break;
            case RarityTypes.Epic:
                playerStats.maxHealth = playerStats.maxHealth + 2;
                break;
            case RarityTypes.Legendary:
                playerStats.maxHealth = playerStats.maxHealth + 5;
                break;
        }
    }
}
