using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] int maxUpgrades;
    [SerializeField] List<int> Cost;
    [SerializeField] int upgradeAmount;

    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] TextMeshProUGUI UnlockText;
    [SerializeField] string UpgradeName;

    public int getMaxUpgrades()
    {
        return maxUpgrades;
    }

    public int getCost()
    {
        int cost = 0;
        if (MetaProgression.GetIntStat(UpgradeName + "Unlocks") < maxUpgrades)
        {
            cost = Cost[MetaProgression.GetIntStat(UpgradeName + "Unlocks")];
        }

        return cost;
    }

    public int getUpgradeAmount()
    {
        return upgradeAmount;
    }

    private void Update()
    {
        if (getCost() == 0)
        {
            costText.text = "---";
        }
        else
        {
            costText.text = getCost().ToString();
        }
        UnlockText.text = MetaProgression.GetIntStat(UpgradeName + "Unlocks").ToString() + " | " + maxUpgrades.ToString();
    }
}
