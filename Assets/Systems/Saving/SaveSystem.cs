using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] PlayerStats Stats;
    [SerializeField] SaveFile SaveFile;
    [SerializeField] List<OneTimeBuffs> OneTimeBuff;

    private void Awake()
    {
        LoadGame();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveFile_FullGame.json"))
        {
            string saveFile = File.ReadAllText(Application.persistentDataPath + "/SaveFile_FullGame.json");
            SaveFile tempSaveFile = ScriptableObject.CreateInstance<SaveFile>();
            JsonUtility.FromJsonOverwrite(saveFile, tempSaveFile);

            SaveFile.coins = tempSaveFile.coins;
            SaveFile.AbilityCooldown = tempSaveFile.AbilityCooldown;
            SaveFile.AbilityDamage = tempSaveFile.AbilityDamage;
            SaveFile.AttackSpeed = tempSaveFile.AttackSpeed;
            SaveFile.BonusAttack = tempSaveFile.BonusAttack;
            SaveFile.Luck = tempSaveFile.Luck;
            SaveFile.maxHealth = tempSaveFile.maxHealth;
            SaveFile.critDamage = tempSaveFile.critDamage;
            SaveFile.critRate = tempSaveFile.critRate;
            SaveFile.Skins = tempSaveFile.Skins;
            SaveFile.Buffs = tempSaveFile.Buffs;
            SaveFile.ActiveSkin = tempSaveFile.ActiveSkin;
            SaveFile.ActiveEnemySkin = tempSaveFile.ActiveEnemySkin;

            for (int i = 0; i < tempSaveFile.abilitiesUnlocks.Count; i++)
            {
                SaveFile.abilities[i].Unlocked = tempSaveFile.abilitiesUnlocks[i].unlocked;
            }

            foreach (var buff in SaveFile.Buffs)
            {
                switch (buff)
                {
                    case StatType.BonusAttack:
                        OneTimeBuffs buff_1 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                        buff_1 = OneTimeBuff[0];
                        Stats.Buffs.Add(buff_1);
                        break;
                    case StatType.Luck:
                        OneTimeBuffs buff_2 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                        buff_2 = OneTimeBuff[1];
                        Stats.Buffs.Add(buff_2);
                        break;
                    case StatType.AttackSpeed:
                        OneTimeBuffs buff_3 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                        buff_3 = OneTimeBuff[2];
                        Stats.Buffs.Add(buff_3);
                        break;
                    case StatType.critRate:
                        OneTimeBuffs buff_4 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                        buff_4 = OneTimeBuff[3];
                        Stats.Buffs.Add(buff_4);
                        break;
                    case StatType.critDamage:
                        OneTimeBuffs buff_5 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                        buff_5 = OneTimeBuff[4];
                        Stats.Buffs.Add(buff_5);
                        break;
                    case StatType.AbilityDamage:
                        OneTimeBuffs buff_6 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                        buff_6 = OneTimeBuff[5];
                        Stats.Buffs.Add(buff_6);
                        break;
                    case StatType.AbilityCooldown:
                        OneTimeBuffs buff_7 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                        buff_7 = OneTimeBuff[6];
                        Stats.Buffs.Add(buff_7);
                        break;
                    case StatType.maxHealth:
                        OneTimeBuffs buff_8 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                        buff_8 = OneTimeBuff[7];
                        Stats.Buffs.Add(buff_8);
                        break;
                }
            }
        }
        else
        {
            SaveGame();
            Debug.LogWarning("File does not exist");
        }
    }

    public void SaveGame()
    {
        SaveFile.abilitiesUnlocks.Clear();

        foreach (var ability in SaveFile.abilities)
        {
            SaveFile.abilitiesUnlocks.Add(new AbilityUnlock(ability.Unlocked));
        }

        string saveFile = JsonUtility.ToJson(SaveFile);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile_FullGame.json", saveFile);
    }
}
