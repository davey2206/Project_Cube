using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MetaStats", menuName = "ScriptableObjects/MetaStats")]
public class MetaStats : ScriptableObject
{
    //coins
    public int Coins;

    //stats
    public float BonusAttack;
    public float Luck;
}
