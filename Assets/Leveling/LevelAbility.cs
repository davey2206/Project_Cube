using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelAbility : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameOfAbility;
    [SerializeField] abilitiesObject abilities;
    [SerializeField] abilitiesObject extraAbilities;
    [SerializeField] GameObject buttons;
    [SerializeField] Leveling leveling;
    public void LevelAbilityClick()
    {
        Time.timeScale = 1;
        buttons.SetActive(false);
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
            foreach (var ability in extraAbilities.abilities)
            {
                if (ability.Name == nameOfAbility.text)
                {
                    ability.Ability.Invoke(1, Vector3.zero);
                }
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
