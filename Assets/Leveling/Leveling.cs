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
    [Header("UI")]
    [SerializeField] GameObject buttons;
    [SerializeField] List<TextMeshProUGUI> Levels;
    [SerializeField] List<TextMeshProUGUI> Names;
    [SerializeField] List<TextMeshProUGUI> Descriptions;
    [SerializeField] List<Image> Icons;
    [SerializeField] Slider xpBar;

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
            if (abilitiesThatCanLevel != null && abilitiesThatCanLevel.Count != 0 && gainAbiltiy)
            {
                abilityToUse = abilitiesThatCanLevel[Random.Range(0, abilitiesThatCanLevel.Count)];
                Names[i].text = abilityToUse.Name;
                abilityLevel = abilityToUse.Level + 1;
                Levels[i].text = "Lvl " + abilityLevel.ToString();
                Descriptions[i].text = abilityToUse.Description[abilityToUse.Level];
                Icons[i].sprite = abilityToUse.Icon;
                Icons[i].color = Color.white;
                abilitiesThatCanLevel.Remove(abilityToUse);
            }
            else
            {
                abilityLevel = 0;
                int rng = Random.Range(0, 101);
                if (rng > 40)
                {
                    abilityToUse = SetButtons(i, RarityTypes.Common, Color.white);
                }
                else if (rng < 40 && rng > 15)
                {
                    abilityToUse = SetButtons(i, RarityTypes.Uncommon, Color.green);
                }
                else if (rng < 15 && rng > 6)
                {
                    abilityToUse = SetButtons(i, RarityTypes.Rare, Color.blue);
                }
                else if (rng < 6 && rng > 1)
                {
                    abilityToUse = SetButtons(i, RarityTypes.Epic, Color.magenta);
                }
                else if (rng < 1)
                {
                    abilityToUse = SetButtons(i, RarityTypes.Legendary, Color.yellow);
                }
            }

            Fix(i, abilityToUse, abilityLevel);
        }

        gainAbiltiy = !gainAbiltiy;
    }
    public void Fix(int i, ability abilityToUse, int level)
    {
        if (Names[i].text != abilityToUse.Name || Descriptions[i].text != abilityToUse.Description[0])
        {
            Debug.Log("Fix?");
            Names[i].text = abilityToUse.Name;
            if (level > 0)
            {
                Levels[i].text = "Lvl " + level;
                Descriptions[i].text = abilityToUse.Description[level];
            }
            else
            {
                Levels[i].text = "";
                Descriptions[i].text = abilityToUse.Description[0];
            }
            Icons[i].sprite = abilityToUse.Icon;

            switch (abilityToUse.rarity)
            {
                case RarityTypes.Common:
                    Descriptions[i].transform.parent.GetComponent<LevelAbility>().rarity = RarityTypes.Common;
                    Icons[i].color = Color.white;
                    break;
                case RarityTypes.Uncommon:
                    Descriptions[i].transform.parent.GetComponent<LevelAbility>().rarity = RarityTypes.Uncommon;
                    Icons[i].color = Color.green;
                    break;
                case RarityTypes.Rare:
                    Descriptions[i].transform.parent.GetComponent<LevelAbility>().rarity = RarityTypes.Rare;
                    Icons[i].color = Color.blue;
                    break;
                case RarityTypes.Epic:
                    Descriptions[i].transform.parent.GetComponent<LevelAbility>().rarity = RarityTypes.Epic;
                    Icons[i].color = Color.magenta;
                    break;
                case RarityTypes.Legendary:
                    Descriptions[i].transform.parent.GetComponent<LevelAbility>().rarity = RarityTypes.Legendary;
                    Icons[i].color = Color.yellow;
                    break;
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

        Descriptions[i].transform.parent.GetComponent<LevelAbility>().rarity = rarity;
        Names[i].text = abilityToUse.Name;
        Levels[i].text = "";
        Descriptions[i].text = abilityToUse.Description[0];
        Icons[i].sprite = abilityToUse.Icon;
        Icons[i].color = color;

        return abilityToUse;
    }

    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(0.5f);
        buttons.SetActive(true);
        LevelUp();
        Time.timeScale = 0;
    }

    public void resetXp()
    {
        Level++;
        xp = 0 + excesXP;
        IsLeveling = false;
    }
}
