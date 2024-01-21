using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ability", menuName = "ScriptableObjects/abilityObject")]
[Serializable]
public class ability : ScriptableObject
{
    public string Name;
    public List<GameObject> Card;
    public RarityTypes rarity;

    [Header("Level")]
    [Range(0,5)]
    public int Level;
    public bool Active;
    public bool Unlocked;

    [Header("Ability")]
    public AbilityTypes abilityType;
    [Space(10)]
    public UnityEvent<int, Vector3> Ability;

    public void LevelUp()
    {
        Level++;
    }
}


public enum AbilityTypes
{
    EnemyDeath,
    Click,
    PlayerHit,
    Timed,
    OneTime
}

public enum RarityTypes
{
    Ability,
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}