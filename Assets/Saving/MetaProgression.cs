using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaProgression : MonoBehaviour
{
    //all
    public static int GetIntStat(string name) { return PlayerPrefs.GetInt(name); }
    public static void SaveIntStat(string name, int amount) { PlayerPrefs.SetInt(name, amount); }


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
}
