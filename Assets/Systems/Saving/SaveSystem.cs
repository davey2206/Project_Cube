using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] SaveFile SaveFile;

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

            for (int i = 0; i < tempSaveFile.abilitiesUnlocks.Count; i++)
            {
                SaveFile.abilities[i].Unlocked = tempSaveFile.abilitiesUnlocks[i].unlocked;
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
