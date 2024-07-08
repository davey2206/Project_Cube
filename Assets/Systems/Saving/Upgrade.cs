using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [Header("SaveFile")]
    [SerializeField] SaveFile saveFile;

    [Header("Upgrade")]
    [SerializeField] UpgradeStat upgradeStat;
    [SerializeField] int maxUnlocks = 1;
    [SerializeField] float unlockAmount;
    [SerializeField] List<int> costs;

    [Header("Ability")]
    [SerializeField] ability ability;
    [SerializeField] bool isAbility;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI unlockText;
    [SerializeField] TextMeshProUGUI costText;

    private SaveSystem saveSystem;
    private int unlock = 0;

    private void Start()
    {
        saveSystem = GameObject.Find("SaveSystem").GetComponent<SaveSystem>();
        GetUnlockedAmount();
        UpdateUI();
    }

    public void BuyUpgrade()
    {
        if (unlock != maxUnlocks && saveFile.coins >= costs[unlock])
        {
            saveFile.coins = saveFile.coins - costs[unlock];
            if (isAbility)
            {
                BuyAbility();
            }
            else
            {
                BuyStat();
            }

            unlock++;

            UpdateUI();

            saveSystem.SaveGame();
        }
    }

    private void UpdateUI()
    {
        unlockText.text = unlock.ToString() + " | " + maxUnlocks;

        if (unlock == maxUnlocks)
        {
            costText.text = "----";
        }
        else
        {
            costText.text = costs[unlock].ToString();
        }
    }

    private void BuyAbility()
    {
        ability.Unlocked = true;
    }

    private void BuyStat()
    {
        switch (upgradeStat)
        {
            case UpgradeStat.Luck:
                saveFile.Luck += unlockAmount;
                break;
            case UpgradeStat.maxHealth:
                saveFile.maxHealth += unlockAmount;
                break;
            case UpgradeStat.AttackSpeed:
                saveFile.AttackSpeed += unlockAmount;
                break;
            case UpgradeStat.critRate:
                saveFile.critRate += unlockAmount;
                break;
            case UpgradeStat.critDamage:
                saveFile.critDamage += unlockAmount;
                break;
            case UpgradeStat.BonusAttack:
                saveFile.BonusAttack += unlockAmount;
                break;
            case UpgradeStat.AbilityDamage:
                saveFile.AbilityDamage += unlockAmount;
                break;
            case UpgradeStat.AbilityCooldown:
                saveFile.AbilityCooldown += unlockAmount;
                break;
        }
    }

    public void GetUnlockedAmount()
    {
        if (isAbility)
        {
            if (ability.Unlocked == true)
            {
                unlock = 1;
            }
        }
        else
        {
            switch (upgradeStat)
            {
                case UpgradeStat.Luck:
                    unlock = (int)(saveFile.Luck / unlockAmount);
                    break;
                case UpgradeStat.maxHealth:
                    unlock = (int)(saveFile.maxHealth / unlockAmount);
                    break;
                case UpgradeStat.AttackSpeed:
                    unlock = (int)(saveFile.AttackSpeed / unlockAmount);
                    break;
                case UpgradeStat.critRate:
                    unlock = (int)(saveFile.critRate / unlockAmount);
                    break;
                case UpgradeStat.critDamage:
                    unlock = (int)(saveFile.critDamage / unlockAmount);
                    break;
                case UpgradeStat.BonusAttack:
                    unlock = (int)(saveFile.BonusAttack / unlockAmount);
                    break;
                case UpgradeStat.AbilityDamage:
                    unlock = (int)(saveFile.AbilityDamage / unlockAmount);
                    break;
                case UpgradeStat.AbilityCooldown:
                    unlock = (int)(saveFile.AbilityCooldown / unlockAmount);
                    break;
            }
        }
    }
}

public enum UpgradeStat
{
    Luck,
    maxHealth,
    AttackSpeed,
    critRate,
    critDamage,
    BonusAttack,
    AbilityDamage,
    AbilityCooldown,
}
