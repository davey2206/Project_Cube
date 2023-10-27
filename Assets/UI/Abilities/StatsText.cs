using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsText : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] TextMeshProUGUI statsText;

    // Update is called once per frame
    void Update()
    {
        statsText.text = "Max Health " + playerStats.maxHealth.ToString() + Environment.NewLine +
            "Bonus Damage " + playerStats.BonusAttack.ToString() + "%" + Environment.NewLine +
            "Attack Speed " + playerStats.AttackSpeed.ToString() + Environment.NewLine +
            "<color=#ffff00ff>Bonus Yellow Damage " + playerStats.YellowDamage.ToString() + "%</color>" + Environment.NewLine +
            "<color=#008000ff>Bonus Green Damage " + playerStats.GreenDamage.ToString() + "%</color>" + Environment.NewLine +
            "<color=#00ffffff>Bonus Blue Damage " + playerStats.BlueDamage.ToString() + "%</color>";
    }
}
