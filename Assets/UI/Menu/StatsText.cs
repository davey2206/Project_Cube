using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsText : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] TextMeshProUGUI baseAttack;
    [SerializeField] TextMeshProUGUI bonusAttack;
    [SerializeField] TextMeshProUGUI AbiltyDamage;
    [SerializeField] TextMeshProUGUI Cooldown;
    [SerializeField] TextMeshProUGUI MaxHealth;
    [SerializeField] TextMeshProUGUI Luck;
    [SerializeField] TextMeshProUGUI CritRate;
    [SerializeField] TextMeshProUGUI CritDamage;

    // Update is called once per frame
    void Update()
    {
        baseAttack.text = Math.Round(playerStats.BaseAttack * 10).ToString();
        bonusAttack.text = playerStats.BonusAttack.ToString() + "%";
        AbiltyDamage.text = playerStats.AbilityDamage.ToString() + "%";
        Cooldown.text = (playerStats.AbilityCooldown * 10).ToString();
        MaxHealth.text = playerStats.maxHealth.ToString();
        Luck.text = playerStats.Luck.ToString();
        CritRate.text = playerStats.critRate.ToString() + "%";
        CritDamage.text = playerStats.critDamage.ToString() + "%";
    }
}
