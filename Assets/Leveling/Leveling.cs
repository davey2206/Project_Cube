using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Leveling : MonoBehaviour
{
    [SerializeField] int Level;
    [SerializeField] int xp;
    [SerializeField] public AnimationCurve xpNeededPerLevel;
    [SerializeField] abilitiesObject abilities;
    [SerializeField] abilitiesObject extraAbilities;

    //UI
    [SerializeField] GameObject buttons;
    [SerializeField] List<TextMeshProUGUI> Names;
    [SerializeField] List<TextMeshProUGUI> Descriptions;

    private void Awake()
    {
        foreach (var ability in abilities.abilities)
        {
            ability.Active = false;
            ability.Level = 0;
        }
    }

    public void addXp(int amount)
    {
        xp = xp + amount;

        if (xp >= (int)xpNeededPerLevel.Evaluate(Level))
        {
            int excesXP = xp - (int)xpNeededPerLevel.Evaluate(Level);
            LevelUp();
            xp = 0 + excesXP;
        }
    }

    public void LevelUp()
    {
        StartCoroutine(TimeStop());
        Level++;
        List<ability> abilitiesThatCanLevel = new List<ability>();

        foreach (var ability in abilities.abilities)
        {
            if (ability.Level < 5)
            {
                abilitiesThatCanLevel.Add(ability);
            }
        }

        ability abilityToUse;

        for (int i = 0; i < 3; i++)
        {
            if (abilitiesThatCanLevel != null && abilitiesThatCanLevel.Count != 0)
            {
                abilityToUse = abilitiesThatCanLevel[Random.Range(0, abilitiesThatCanLevel.Count)];
                Names[i].text = abilityToUse.Name;
                Descriptions[i].text = abilityToUse.Description[abilityToUse.Level];
                abilitiesThatCanLevel.Remove(abilityToUse);
            }
            else
            {
                abilityToUse = extraAbilities.abilities[Random.Range(0, extraAbilities.abilities.Count)];
                Names[i].text = abilityToUse.Name;
                Descriptions[i].text = abilityToUse.Description[0];
            }
            
        }
    }

    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(0.5f);

        buttons.SetActive(true);
        Time.timeScale = 0;
    }
}
