using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] RarityTypes rarity;
    public void Ability(int level, Vector3 pos)
    {
        switch (rarity)
        {
            case RarityTypes.Common:
                GameObject.Find("Player").GetComponent<Player>().Heal(2);
                break;
            case RarityTypes.Uncommon:
                GameObject.Find("Player").GetComponent<Player>().Heal(3);
                break;
            case RarityTypes.Rare:
                GameObject.Find("Player").GetComponent<Player>().Heal(5);
                break;
            case RarityTypes.Epic:
                GameObject.Find("Player").GetComponent<Player>().Heal(8);
                break;
            case RarityTypes.Legendary:
                GameObject.Find("Player").GetComponent<Player>().Heal(15);
                break;
        }
    }
}
