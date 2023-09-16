using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelAbility : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameOfAbility;
    [SerializeField] abilitiesObject abilities;
    [SerializeField] GameObject buttons;
    public void LevelAbilityClick()
    {
        Time.timeScale = 1;
        buttons.SetActive(false);

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
}
