using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class ability
{
    [Header("Description")]
    public Sprite Icon;
    public string Name;
    [TextArea]
    public List<string> Description;
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
    Timed
}

public enum RarityTypes
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}