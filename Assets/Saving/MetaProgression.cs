using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaProgression : MonoBehaviour
{
    public static void SaveAttackBonus(int attack) { PlayerPrefs.SetInt("Attack", attack); }
    public static void SaveAttackBonusUnlocks(int unlocks) { PlayerPrefs.SetInt("AttackUnlocks", unlocks); }
    public static int GetAttackBonus() { return PlayerPrefs.GetInt("Attack"); }
    public static int GetAttackBonusUnlocks() { return PlayerPrefs.GetInt("AttackUnlocks"); }

    public static void SaveLuckBonus(int luck) { PlayerPrefs.SetInt("Luck", luck); }
    public static void SaveLuckBonusUnlocks(int Unlocks) { PlayerPrefs.SetInt("LuckUnlocks", Unlocks); }
    public static int GetLuckBonus() { return PlayerPrefs.GetInt("Luck"); }
    public static int GetLuckBonusUnlocks() { return PlayerPrefs.GetInt("LuckUnlocks"); }

    public static void SaveCoins(int coins) { PlayerPrefs.SetInt("Coins", coins); }
    public static int GetCoins() { return PlayerPrefs.GetInt("Coins"); }
}
