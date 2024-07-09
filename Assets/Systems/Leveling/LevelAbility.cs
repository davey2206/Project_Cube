using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelAbility : MonoBehaviour
{
    public ability Ability;

    public void LevelAbilityClick()
    {
        if (Ability.rarity == RarityTypes.Ability)
        {
            if (Ability.Active == false)
            {
                Ability.Active = true;
            }
            Ability.LevelUp();

            if (Ability.abilityType == AbilityTypes.Timed)
            {
                Ability.Ability.Invoke(Ability.Level, Vector3.zero);
            }
        }
        else
        {
            if (Ability.abilityType == AbilityTypes.OneTime)
            {
                Ability.Ability.Invoke(1, Vector3.zero);
            }
        }

        GameObject.Find("AbilitySelect").GetComponent<ResetCards>().DeleteCards();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
