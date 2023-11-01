using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Leveling : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] int Level;
    [SerializeField] int xp;
    [SerializeField] public AnimationCurve xpNeededPerLevel;
    [SerializeField] abilitiesObject abilities;
    [SerializeField] List<abilitiesObject> extraAbilities;
    [SerializeField] PlayerStats playerStats;

    //UI
    [SerializeField] Slider xpBar;

    [Header("Abilitie")]
    [SerializeField] GameObject buttons;
    [SerializeField] List<TextMeshProUGUI> Levels;
    [SerializeField] List<TextMeshProUGUI> Names;
    [SerializeField] List<TextMeshProUGUI> Descriptions;
    [SerializeField] List<Image> Icons;

    [Header("Stats")]
    [SerializeField] GameObject buttonsStats;
    [SerializeField] List<TextMeshProUGUI> NamesStats;
    [SerializeField] List<TextMeshProUGUI> DescriptionsStats;
    [SerializeField] List<Image> IconsStats;

    float Velocity;
    int excesXP = 0;
    bool IsLeveling;
    bool gainAbiltiy;
    private void Awake()
    {
        gainAbiltiy = true;
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

        if (xp >= (int)xpNeededPerLevel.Evaluate(Level) && !IsLeveling && playerStats.alive)
        {
            IsLeveling = true;
            excesXP = 0;
            excesXP = xp - (int)xpNeededPerLevel.Evaluate(Level);
            StartCoroutine(TimeStop());
        }
    }

    public void LevelUp()
    {
        List<ability> abilitiesThatCanLevel = new List<ability>();

        foreach (var ability in abilities.abilities)
        {
            if (ability.Level < 5 && ability.Unlocked)
            {
                abilitiesThatCanLevel.Add(ability);
            }
        }

        ability abilityToUse = null;
        int abilityLevel = 0;

        for (int i = 0; i < 3; i++)
        {
            abilityToUse = abilitiesThatCanLevel[Random.Range(0, abilitiesThatCanLevel.Count)];
            Names[i].text = abilityToUse.Name;
            abilityLevel = abilityToUse.Level + 1;
            Levels[i].text = "Lvl " + abilityLevel.ToString();
            Descriptions[i].text = abilityToUse.Description[abilityToUse.Level];
            Icons[i].sprite = abilityToUse.Icon;
            abilitiesThatCanLevel.Remove(abilityToUse);
        }
    }

    public void LevelUpStats()
    {
        for (int i = 0; i < 3; i++)
        {
            int rng = Random.Range(0, 101);
            if (rng > 40)
            {
                SetButtons(i, RarityTypes.Common, Color.white);
            }
            else if (rng < 40 && rng > 15)
            {
                SetButtons(i, RarityTypes.Uncommon, Color.green);
            }
            else if (rng < 15 && rng > 6)
            {
                SetButtons(i, RarityTypes.Rare, Color.blue);
            }
            else if (rng < 6 && rng > 1)
            {
                SetButtons(i, RarityTypes.Epic, Color.magenta);
            }
            else if (rng < 1)
            {
                SetButtons(i, RarityTypes.Legendary, Color.yellow);
            }
        }
    }

    public ability SetButtons(int i, RarityTypes rarity, Color color)
    {
        ability abilityToUse = null;
        switch (rarity)
        {
            case RarityTypes.Common:
                abilityToUse = extraAbilities[0].abilities[Random.Range(0, extraAbilities[0].abilities.Count)];
                break;
            case RarityTypes.Uncommon:
                abilityToUse = extraAbilities[1].abilities[Random.Range(0, extraAbilities[1].abilities.Count)];
                break;
            case RarityTypes.Rare:
                abilityToUse = extraAbilities[2].abilities[Random.Range(0, extraAbilities[2].abilities.Count)];
                break;
            case RarityTypes.Epic:
                abilityToUse = extraAbilities[3].abilities[Random.Range(0, extraAbilities[3].abilities.Count)];
                break;
            case RarityTypes.Legendary:
                abilityToUse = extraAbilities[4].abilities[Random.Range(0, extraAbilities[4].abilities.Count)];
                break;
        }

        DescriptionsStats[i].transform.parent.GetComponent<LevelAbility>().rarity = rarity;
        NamesStats[i].text = abilityToUse.Name;
        Levels[i].text = "";
        DescriptionsStats[i].text = abilityToUse.Description[0];
        IconsStats[i].sprite = abilityToUse.Icon;
        IconsStats[i].color = color;

        return abilityToUse;
    }

    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(0.5f);
        if (gainAbiltiy)
        {
            buttons.SetActive(true);
            LevelUp();
            yield return new WaitForEndOfFrame();
            LevelUp();
            gainAbiltiy = !gainAbiltiy;
        }
        else
        {
            buttonsStats.SetActive(true);
            LevelUpStats();
            yield return new WaitForEndOfFrame();
            LevelUpStats();
            gainAbiltiy = !gainAbiltiy;
        }
        yield return new WaitForEndOfFrame();
        Time.timeScale = 0;
    }

    public void resetXp()
    {
        Level++;
        xp = 0 + excesXP;
        IsLeveling = false;
    }
}
