using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Coins;
    [SerializeField] MetaStats stats;
    [SerializeField] List<Upgrade> upgradeList;

    private void Start()
    {
        setCoinText();
    }

    public void setCoinText()
    {
        Coins.text = "Coins: " + stats.Coins.ToString();
    }

    public void Attack(TextMeshProUGUI name)
    {
        Upgrade u = null;
        foreach (Upgrade upgrade in upgradeList)
        {
            if (upgrade.Name == name.text)
            {
                u = upgrade;
            }
        }

        if (u.getCost() != "----")
        {
            int cost = int.Parse(u.getCost());

            if (stats.Coins >= cost && u.Unlocks.x != u.Unlocks.y)
            {
                stats.Coins -= cost;
                stats.BonusAttack += 10;
                u.Unlocks.x += 1;
                setCoinText();
            }
        }
    }

    public void Luck(TextMeshProUGUI name)
    {
        Upgrade u = null;
        foreach (Upgrade upgrade in upgradeList)
        {
            if (upgrade.Name == name.text)
            {
                u = upgrade;
            }
        }

        if (u.getCost() != "----")
        {
            int cost = int.Parse(u.getCost());

            if (stats.Coins >= cost && u.Unlocks.x != u.Unlocks.y)
            {
                stats.Coins -= cost;
                stats.Luck += 1;
                u.Unlocks.x += 1;
                setCoinText();
            }
        }
    }
}
