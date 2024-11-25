using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{
    [SerializeField] int skinNumber;
    [SerializeField] bool isPlayer = true;

    [Header("Save File")]
    [SerializeField] SaveFile Save;
    [SerializeField] PlayerStats PlayerStats;
    [SerializeField] EnemySkinObject EnemySkinObject;

    [Header("Refs")]
    [SerializeField] GameObject UnlockedSkin;
    [SerializeField] GameObject LockedSkin;
    [SerializeField] Image buttonImage;
    [SerializeField] Button button;

    [Header("Colors")]
    [SerializeField] Color color_1;
    [SerializeField] Color color_2;

    private void Update()
    {
        CheckUnlocked();
        CheckSelected();
    }

    void CheckUnlocked()
    {
        if (Save.Skins[skinNumber])
        {
            UnlockedSkin.SetActive(true);
            LockedSkin.SetActive(false);
            button.enabled = true;
        }
        else
        {
            button.enabled = false;
            UnlockedSkin.SetActive(false);
            LockedSkin.SetActive(true);
        }
    }

    void CheckSelected()
    {
        if (isPlayer && Save.ActiveSkin == skinNumber)
        {
            buttonImage.color = color_1;
        }
        else if (isPlayer)
        {
            buttonImage.color = color_2;
        }

        if (!isPlayer && Save.ActiveEnemySkin == skinNumber)
        {
            buttonImage.color = color_1;
        }
        else if (!isPlayer)
        {
            buttonImage.color = color_2;
        }
    }

    public void SelectSkin()
    {
        if (isPlayer)
        {
            Save.ActiveSkin = skinNumber;
            PlayerStats.UpdateSkin();
        }
        else
        {
            Save.ActiveEnemySkin = skinNumber;
            EnemySkinObject.UpdateSkin();
        }
    }
}
