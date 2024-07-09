using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritRate : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] RarityTypes rarity;
    public void Ability(int level, Vector3 pos)
    {
        switch (rarity)
        {
            case RarityTypes.Common:
                playerStats.critRate = playerStats.critRate + 2.5f;
                break;
            case RarityTypes.Uncommon:
                playerStats.critRate = playerStats.critRate + 5;
                break;
            case RarityTypes.Rare:
                playerStats.critRate = playerStats.critRate + 7.5f;
                break;
            case RarityTypes.Epic:
                playerStats.critRate = playerStats.critRate + 10;
                break;
            case RarityTypes.Legendary:
                playerStats.critRate = playerStats.critRate + 15;
                break;
        }
    }
}
