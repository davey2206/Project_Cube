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

        switch (abilitiesThatCanLevel.Count)
        {
            case 1:
                abilityToUse = abilitiesThatCanLevel[Random.Range(0, abilitiesThatCanLevel.Count)];
                Names[0].text = abilityToUse.Name;
                Descriptions[0].text = abilityToUse.Description[abilityToUse.Level];
                break;
            case 2:
                abilityToUse = abilitiesThatCanLevel[Random.Range(0, abilitiesThatCanLevel.Count)];
                Names[0].text = abilityToUse.Name;
                Descriptions[0].text = abilityToUse.Description[abilityToUse.Level];
                abilitiesThatCanLevel.Remove(abilityToUse);

                abilityToUse = abilitiesThatCanLevel[Random.Range(0, abilitiesThatCanLevel.Count)];
                Names[1].text = abilityToUse.Name;
                Descriptions[1].text = abilityToUse.Description[abilityToUse.Level];
                break;
            default:
                abilityToUse = abilitiesThatCanLevel[Random.Range(0, abilitiesThatCanLevel.Count)];
                Names[0].text = abilityToUse.Name;
                Descriptions[0].text = abilityToUse.Description[abilityToUse.Level];
                abilitiesThatCanLevel.Remove(abilityToUse);

                abilityToUse = abilitiesThatCanLevel[Random.Range(0, abilitiesThatCanLevel.Count)];
                Names[1].text = abilityToUse.Name;
                Descriptions[1].text = abilityToUse.Description[abilityToUse.Level];
                abilitiesThatCanLevel.Remove(abilityToUse);

                abilityToUse = abilitiesThatCanLevel[Random.Range(0, abilitiesThatCanLevel.Count)];
                Names[2].text = abilityToUse.Name;
                Descriptions[2].text = abilityToUse.Description[abilityToUse.Level];
                break;
        }
    }

    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(0.5f);

        buttons.SetActive(true);
        Time.timeScale = 0;
    }
}
