using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ability
{
    [Header("Description")]
    public string Name;
    [TextArea]
    public List<string> Description;

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