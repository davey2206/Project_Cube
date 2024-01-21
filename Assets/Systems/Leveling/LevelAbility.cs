using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelAbility : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameOfAbility;
    [SerializeField] abilitiesObject abilities;
    [SerializeField] List<abilitiesObject> extraAbilities;
    [SerializeField] GameObject buttons;
    [SerializeField] Leveling leveling;

    public RarityTypes rarity;
    public void LevelAbilityClick()
    {
        Time.timeScale = 1;
        buttons.GetComponent<Animator>().SetTrigger("PopOut");
        leveling.resetXp();
        if (CheckAbility())
        {
            foreach (var ability in abilities.abilities)
            {
                if (ability.Name == nameOfAbility.text)
                {
                    if (ability.Active == false)
                    {
                        ability.Active = true;
                        ability.LevelUp();
                        if (ability.abilityType == AbilityTypes.Timed)
                        {
                            ability.Ability.Invoke(ability.Level, Vector3.zero);
                        }
                    }
                    else
                    {
                        ability.LevelUp();

                        if (ability.abilityType == AbilityTypes.Timed)
                        {
                            ability.Ability.Invoke(ability.Level, Vector3.zero);
                        }
                    }
                }
            }
        }
        else
        {
            switch (rarity)
            {
                case RarityTypes.Common:
                    foreach (var ability in extraAbilities[0].abilities)
                    {
                        if (ability.Name == nameOfAbility.text)
                        {
                            ability.Ability.Invoke(1, Vector3.zero);
                        }
                    }
                    break;
                case RarityTypes.Uncommon:
                    foreach (var ability in extraAbilities[1].abilities)
                    {
                        if (ability.Name == nameOfAbility.text)
                        {
                            ability.Ability.Invoke(1, Vector3.zero);
                        }
                    }
                    break;
                case RarityTypes.Rare:
                    foreach (var ability in extraAbilities[2].abilities)
                    {
                        if (ability.Name == nameOfAbility.text)
                        {
                            ability.Ability.Invoke(1, Vector3.zero);
                        }
                    }
                    break;
                case RarityTypes.Epic:
                    foreach (var ability in extraAbilities[3].abilities)
                    {
                        if (ability.Name == nameOfAbility.text)
                        {
                            ability.Ability.Invoke(1, Vector3.zero);
                        }
                    }
                    break;
                case RarityTypes.Legendary:
                    foreach (var ability in extraAbilities[4].abilities)
                    {
                        if (ability.Name == nameOfAbility.text)
                        {
                            ability.Ability.Invoke(1, Vector3.zero);
                        }
                    }
                    break;
            }
        }
    }

    public bool CheckAbility()
    {
        int counter = 0;
        foreach (var ability in abilities.abilities)
        {
            if (ability.Name == nameOfAbility.text)
            {
                counter++;
            }
        }

        if (counter == 0)
        {
            return false;
        }

        return true;
    }
}
