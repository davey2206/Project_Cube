using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] Slider xpBar;

    float Velocity;
    int excesXP = 0;
    bool IsLeveling;
    private void Awake()
    {
        foreach (var ability in abilities.abilities)
        {
            ability.Active = false;
            ability.Level = 0;
        }
    }

    private void Update()
    {
        xpBar.maxValue = (int)xpNeededPerLevel.Evaluate(Level);
        float currentXp = Mathf.SmoothDamp(xpBar.value, xp, ref Velocity, 25 * Time.deltaTime);
        xpBar.value = currentXp;
    }

    public void addXp(int amount)
    {
        xp = xp + amount;

        if (xp >= (int)xpNeededPerLevel.Evaluate(Level) && !IsLeveling)
        {
            IsLeveling = true;
            excesXP = 0;
            excesXP = xp - (int)xpNeededPerLevel.Evaluate(Level);
            LevelUp();
        }
    }

    public void LevelUp()
    {
        StartCoroutine(TimeStop());
        List<ability> abilitiesThatCanLevel = new List<ability>();

        foreach (var ability in abilities.abilities)
        {
            if (ability.Level < 5 && ability.Unlocked)
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

    public void resetXp()
    {
        Level++;
        xp = 0 + excesXP;
        IsLeveling = false;
    }
}
