using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaProgression : MonoBehaviour
{
    //all
    public static int GetIntStat(string name) { return PlayerPrefs.GetInt(name); }
    public static void SaveIntStat(string name, int amount) { PlayerPrefs.SetInt(name, amount); }
    public static string GetStringStat(string name) { return PlayerPrefs.GetString(name); }
    public static void SaveStringStat(string name, string amount) { PlayerPrefs.SetString(name, amount); }
    public static float GetFloatStat(string name) { return PlayerPrefs.GetFloat(name); }
    public static void SaveFloatStat(string name, float amount) { PlayerPrefs.SetFloat(name, amount); }


    //coins
    public static void SaveCoins(int coins) { PlayerPrefs.SetInt("Coins", coins); }
    public static int GetCoins() { return PlayerPrefs.GetInt("Coins"); }


    //attack
    public static void SaveAttackBonus(int attack) { PlayerPrefs.SetInt("Attack", attack); }
    public static void SaveAttackBonusUnlocks(int unlocks) { PlayerPrefs.SetInt("AttackUnlocks", unlocks); }
    public static int GetAttackBonus() { return PlayerPrefs.GetInt("Attack"); }
    public static int GetAttackBonusUnlocks() { return PlayerPrefs.GetInt("AttackUnlocks"); }


    //luck
    public static void SaveLuckBonus(int luck) { PlayerPrefs.SetInt("Luck", luck); }
    public static void SaveLuckBonusUnlocks(int Unlocks) { PlayerPrefs.SetInt("LuckUnlocks", Unlocks); }
    public static int GetLuckBonus() { return PlayerPrefs.GetInt("Luck"); }
    public static int GetLuckBonusUnlocks() { return PlayerPrefs.GetInt("LuckUnlocks"); }


    //AttackSpeed
    public static void SaveAttackSpeedBonus(int AttackSpeed) { PlayerPrefs.SetInt("AttackSpeed", AttackSpeed); }
    public static void SaveAttackSpeedBonusUnlocks(int Unlocks) { PlayerPrefs.SetInt("AttackSpeedUnlocks", Unlocks); }
    public static int GetAttackSpeedBonus() { return PlayerPrefs.GetInt("AttackSpeed"); }
    public static int GetAttackSpeedBonusUnlocks() { return PlayerPrefs.GetInt("AttackSpeedUnlocks"); }

    //CritRate
    public static void SaveCritRateBonus(int CritRate) { PlayerPrefs.SetInt("CritRate", CritRate); }
    public static void SaveCritRateBonusUnlocks(int Unlocks) { PlayerPrefs.SetInt("CritRateUnlocks", Unlocks); }
    public static int GetCritRateBonus() { return PlayerPrefs.GetInt("CritRate"); }
    public static int GetCritRateBonusUnlocks() { return PlayerPrefs.GetInt("CritRateUnlocks"); }

    //CritDamage
    public static void SaveCritDamageBonus(int CritDamage) { PlayerPrefs.SetInt("CritDamage", CritDamage); }
    public static void SaveCritDamageBonusUnlocks(int Unlocks) { PlayerPrefs.SetInt("CritDamageUnlocks", Unlocks); }
    public static int GetCritDamageBonus() { return PlayerPrefs.GetInt("CritDamage"); }
    public static int GetCritDamageBonusUnlocks() { return PlayerPrefs.GetInt("CritDamageUnlocks"); }

    //AbilityDamage
    public static void SaveAbilityDamageBonus(int AbilityDamage) { PlayerPrefs.SetInt("AbilityDamage", AbilityDamage); }
    public static void SaveAbilityDamageBonusUnlocks(int Unlocks) { PlayerPrefs.SetInt("AbilityDamageUnlocks", Unlocks); }
    public static int GetAbilityDamageBonus() { return PlayerPrefs.GetInt("AbilityDamage"); }
    public static int GetAbilityDamageBonusUnlocks() { return PlayerPrefs.GetInt("AbilityDamageUnlocks"); }

    //AbilityCoolDown
    public static void SaveAbilityCooldownBonus(int AbilityCooldown) { PlayerPrefs.SetInt("AbilityCooldown", AbilityCooldown); }
    public static void SaveAbilityCooldownBonusUnlocks(int Unlocks) { PlayerPrefs.SetInt("AbilityCooldownUnlocks", Unlocks); }
    public static int GetAbilityCooldownBonus() { return PlayerPrefs.GetInt("AbilityCooldown"); }
    public static int GetAbilityCooldownBonusUnlocks() { return PlayerPrefs.GetInt("AbilityCooldownUnlocks"); }

    //MaxHealth
    public static void SaveMaxHealthBonus(int MaxHealth) { PlayerPrefs.SetInt("MaxHealth", MaxHealth); }
    public static void SaveMaxHealthUnlocks(int Unlocks) { PlayerPrefs.SetInt("MaxHealthUnlocks", Unlocks); }
    public static int GetMaxHealthBonus() { return PlayerPrefs.GetInt("MaxHealth"); }
    public static int GetMaxHealthUnlocks() { return PlayerPrefs.GetInt("MaxHealthUnlocks"); }

    //MaxHealth
    public static void SavePoison(int Poison) { PlayerPrefs.SetInt("Poison", Poison); }
    public static void SavePoisonUnlocks(int Unlocks) { PlayerPrefs.SetInt("PoisonUnlocks", Unlocks); }
    public static int GetPoison() { return PlayerPrefs.GetInt("Poison"); }
    public static int GetPoisonUnlocks() { return PlayerPrefs.GetInt("PoisonUnlocks"); }

    //MaxHealth
    public static void SaveShields(int Shields) { PlayerPrefs.SetInt("Shields", Shields); }
    public static void SaveShieldsUnlocks(int Unlocks) { PlayerPrefs.SetInt("ShieldsUnlocks", Unlocks); }
    public static int GetShields() { return PlayerPrefs.GetInt("Shields"); }
    public static int GetShieldsUnlocks() { return PlayerPrefs.GetInt("ShieldsUnlocks"); }
}
