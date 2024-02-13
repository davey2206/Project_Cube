using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "abilitiesObject", menuName = "ScriptableObjects/AbilitiesObject")]
public class abilitiesObject : ScriptableObject
{
    public List<ability> abilities;

    public void CheckUnlocks()
    {
        foreach (var ability in abilities)
        {
            if (ability.name == "Poison")
            {
                if (MetaProgression.GetPoison() == 1)
                {
                    ability.Unlocked = true;
                }
                else
                {
                    ability.Unlocked = false;
                }
            }

            if (ability.name == "Shield")
            {
                if (MetaProgression.GetShields() == 1)
                {
                    ability.Unlocked = true;
                }
                else
                {
                    ability.Unlocked = false;
                }
            }
        }
    }
}
