using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MetaUpgrades : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coins;

    private void Start()
    {
        MetaProgression.SaveCoins(2000);
        SetCoinText();
    }

    private void SetCoinText()
    {
        coins.text = "Coins: " + MetaProgression.GetCoins().ToString();
    }

    public void ResetAllStats()
    {
        MetaProgression.SaveAttackBonus(0);
        MetaProgression.SaveAttackBonusUnlocks(0);
        MetaProgression.SaveLuckBonus(0);
        MetaProgression.SaveLuckBonusUnlocks(0);
        MetaProgression.SaveAttackSpeedBonus(0);
        MetaProgression.SaveAttackSpeedBonusUnlocks(0);
        MetaProgression.SaveCoins(2000);

        SetCoinText();
    }

    public void Upgrade(GameObject Upgrade)
    {
        Upgrade u = Upgrade.GetComponent<Upgrade>();
        string upgrade = u.UpgradeName;
        int maxUpgrades = u.getMaxUpgrades();
        int Cost = u.getCost();

        if (MetaProgression.GetCoins() >= Cost)
        {
            if (MetaProgression.GetIntStat(upgrade + "Unlocks") < maxUpgrades)
            {
                MetaProgression.SaveIntStat(upgrade + "Unlocks", MetaProgression.GetIntStat(upgrade + "Unlocks") + 1);
                MetaProgression.SaveCoins(MetaProgression.GetCoins() - Cost);
                MetaProgression.SaveIntStat(upgrade, MetaProgression.GetIntStat(upgrade) + u.getUpgradeAmount());
            }
        }
        SetCoinText();
    }
}
