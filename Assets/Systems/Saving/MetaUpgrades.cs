using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MetaUpgrades : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coins;
    private void Start()
    {
        SetCoinText();
        GameObject.Find("MainCube").GetComponent<MainCubeAnimations>().BackMenu();
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
        MetaProgression.SaveAbilityCooldownBonus(0);
        MetaProgression.SaveAbilityCooldownBonusUnlocks(0);
        MetaProgression.SaveAbilityDamageBonus(0);
        MetaProgression.SaveAbilityDamageBonusUnlocks(0);
        MetaProgression.SaveCoins(0);
        MetaProgression.SaveCritDamageBonus(0);
        MetaProgression.SaveCritDamageBonusUnlocks(0);
        MetaProgression.SaveCritRateBonus(0);
        MetaProgression.SaveCritRateBonusUnlocks(0);
        MetaProgression.SaveMaxHealthBonus(0);
        MetaProgression.SaveMaxHealthUnlocks(0);
        MetaProgression.SavePoison(0);
        MetaProgression.SavePoisonUnlocks(0);
        MetaProgression.SaveShields(0);
        MetaProgression.SaveShieldsUnlocks(0);

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

    public void MultiUpgrade(GameObject Upgrade)
    {
        MultiUpgrade u = Upgrade.GetComponent<MultiUpgrade>();
        List<string> upgrades = u.UpgradeName;
        int maxUpgrades = u.getMaxUpgrades();
        int Cost = u.getCost();

        if (MetaProgression.GetCoins() >= Cost)
        {
            if (MetaProgression.GetIntStat(upgrades[0] + "Unlocks") < maxUpgrades)
            {
                foreach (var upgrade in upgrades)
                {
                    MetaProgression.SaveIntStat(upgrade + "Unlocks", MetaProgression.GetIntStat(upgrade + "Unlocks") + 1);
                    MetaProgression.SaveIntStat(upgrade, MetaProgression.GetIntStat(upgrade) + u.getUpgradeAmount());
                }

                MetaProgression.SaveCoins(MetaProgression.GetCoins() - Cost);
            }
        }
        SetCoinText();
    }
}
