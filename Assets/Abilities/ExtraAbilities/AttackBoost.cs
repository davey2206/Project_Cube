using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoost : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    public void Ability(int level, Vector3 pos)
    {
        playerStats.BonusAttack = playerStats.BonusAttack + 10;
    }
}
