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
        MetaProgression.SaveCoins(0);

        SetCoinText();
    }
}
