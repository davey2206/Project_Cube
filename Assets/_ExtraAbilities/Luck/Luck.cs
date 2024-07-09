using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luck : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] RarityTypes rarity;
    public void Ability(int level, Vector3 pos)
    {
        switch (rarity)
        {
            case RarityTypes.Common:
                playerStats.Luck = playerStats.Luck + 1f;
                break;
            case RarityTypes.Uncommon:
                playerStats.Luck = playerStats.Luck + 2f;
                break;
            case RarityTypes.Rare:
                playerStats.Luck = playerStats.Luck + 3f;
                break;
            case RarityTypes.Epic:
                playerStats.Luck = playerStats.Luck + 5f;
                break;
            case RarityTypes.Legendary:
                playerStats.Luck = playerStats.Luck + 10f;
                break;
        }
    }
}
