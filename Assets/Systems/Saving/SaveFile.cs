using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveFile", menuName = "ScriptableObjects/SaveFile")]
public class SaveFile : ScriptableObject
{
    [Header("Abilties")]
    public List<ability> abilities = new List<ability>();
    public List<AbilityUnlock> abilitiesUnlocks = new List<AbilityUnlock>();

    [Header("Coins")]
    public int coins;

    [Header("Stats")]
    public float Luck;
    public float maxHealth;
    public float AttackSpeed;

    [Header("Crit")]
    public float critRate;
    public float critDamage;

    [Header("Damage")]
    public float BonusAttack;

    [Header("Ability")]
    public float AbilityDamage;
    public float AbilityCooldown;
}
