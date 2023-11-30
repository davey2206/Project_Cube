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

    List<ability> abilitiesThatCanLevelCommon = new List<ability>();
    List<ability> abilitiesThatCanLevelUncommon = new List<ability>();
    List<ability> abilitiesThatCanLevelRare = new List<ability>();
    List<ability> abilitiesThatCanLevelEpic = new List<ability>();
    List<ability> abilitiesThatCanLevelLegendary = new List<ability>();

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

        excesXP = 0;
        excesXP = xp - (int)xpNeededPerLevel.Evaluate(Level);

        if (xp >= (int)xpNeededPerLevel.Evaluate(Level) && !IsLeveling && playerStats.alive)
        {
            IsLeveling = true;
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

    public void AddBaseDamage()
    {
        if (Level < 5)
        {
            playerStats.BaseAttack = playerStats.BaseAttack + 0.1f;
        }
        else if (Level % 5 == 0)
        {
            playerStats.BaseAttack = playerStats.BaseAttack + 0.1f;
        }
    }

    public void LevelUpStats()
    {
        abilitiesThatCanLevelCommon.Clear();
        abilitiesThatCanLevelUncommon.Clear();
        abilitiesThatCanLevelRare.Clear();
        abilitiesThatCanLevelEpic.Clear();
        abilitiesThatCanLevelLegendary.Clear();

        foreach (var ability in extraAbilities[0].abilities)
        {
            abilitiesThatCanLevelCommon.Add(ability);
        }

        foreach (var ability in extraAbilities[1].abilities)
        {
            abilitiesThatCanLevelUncommon.Add(ability);
        }

        foreach (var ability in extraAbilities[2].abilities)
        {
            abilitiesThatCanLevelRare.Add(ability);
        }

        foreach (var ability in extraAbilities[3].abilities)
        {
            abilitiesThatCanLevelEpic.Add(ability);
        }

        foreach (var ability in extraAbilities[4].abilities)
        {
            abilitiesThatCanLevelLegendary.Add(ability);
        }



        for (int i = 0; i < 3; i++)
        {
            int rng = Random.Range(0, 101);
            if (rng > 40)
            {
                ability abilityToUse = SetButtons(i, RarityTypes.Common, Color.white, abilitiesThatCanLevelCommon, abilitiesThatCanLevelUncommon, abilitiesThatCanLevelRare, abilitiesThatCanLevelEpic, abilitiesThatCanLevelLegendary);

                while (!GetComponent<Player>().canHeal() && abilityToUse.Name == "Heal")
                {
                    abilityToUse = SetButtons(i, RarityTypes.Common, Color.white, abilitiesThatCanLevelCommon, abilitiesThatCanLevelUncommon, abilitiesThatCanLevelRare, abilitiesThatCanLevelEpic, abilitiesThatCanLevelLegendary);
                }
            }
            else if (rng < 40 && rng > 15)
            {
                ability abilityToUse = SetButtons(i, RarityTypes.Uncommon, Color.green, abilitiesThatCanLevelCommon, abilitiesThatCanLevelUncommon, abilitiesThatCanLevelRare, abilitiesThatCanLevelEpic, abilitiesThatCanLevelLegendary);

                while (!GetComponent<Player>().canHeal() && abilityToUse.Name == "Heal")
                {
                    abilityToUse = SetButtons(i, RarityTypes.Uncommon, Color.green, abilitiesThatCanLevelCommon, abilitiesThatCanLevelUncommon, abilitiesThatCanLevelRare, abilitiesThatCanLevelEpic, abilitiesThatCanLevelLegendary);
                }
            }
            else if (rng < 15 && rng > 6)
            {
                ability abilityToUse = SetButtons(i, RarityTypes.Rare, Color.blue, abilitiesThatCanLevelCommon, abilitiesThatCanLevelUncommon, abilitiesThatCanLevelRare, abilitiesThatCanLevelEpic, abilitiesThatCanLevelLegendary);

                while (!GetComponent<Player>().canHeal() && abilityToUse.Name == "Heal")
                {
                    abilityToUse = SetButtons(i, RarityTypes.Rare, Color.blue, abilitiesThatCanLevelCommon, abilitiesThatCanLevelUncommon, abilitiesThatCanLevelRare, abilitiesThatCanLevelEpic, abilitiesThatCanLevelLegendary);
                }
            }
            else if (rng < 6 && rng > 1)
            {
                ability abilityToUse = SetButtons(i, RarityTypes.Epic, Color.magenta, abilitiesThatCanLevelCommon, abilitiesThatCanLevelUncommon, abilitiesThatCanLevelRare, abilitiesThatCanLevelEpic, abilitiesThatCanLevelLegendary);

                while (!GetComponent<Player>().canHeal() && abilityToUse.Name == "Heal")
                {
                    abilityToUse = SetButtons(i, RarityTypes.Epic, Color.magenta, abilitiesThatCanLevelCommon, abilitiesThatCanLevelUncommon, abilitiesThatCanLevelRare, abilitiesThatCanLevelEpic, abilitiesThatCanLevelLegendary);
                }
            }
            else if (rng < 1)
            {
                ability abilityToUse = SetButtons(i, RarityTypes.Legendary, Color.yellow, abilitiesThatCanLevelCommon, abilitiesThatCanLevelUncommon, abilitiesThatCanLevelRare, abilitiesThatCanLevelEpic, abilitiesThatCanLevelLegendary);

                while (!GetComponent<Player>().canHeal() && abilityToUse.Name == "Heal")
                {
                    abilityToUse = SetButtons(i, RarityTypes.Legendary, Color.yellow, abilitiesThatCanLevelCommon, abilitiesThatCanLevelUncommon, abilitiesThatCanLevelRare, abilitiesThatCanLevelEpic, abilitiesThatCanLevelLegendary);
                }
            }
        }
    }

    public ability SetButtons(int i, RarityTypes rarity, Color color, List<ability> abilitiesThatCanLevelCommon, List<ability> abilitiesThatCanLevelUncommon, List<ability> abilitiesThatCanLevelRare, List<ability> abilitiesThatCanLevelEpic, List<ability> abilitiesThatCanLevelLegendary)
    {
        ability abilityToUse = null;

        switch (rarity)
        {
            case RarityTypes.Common:
                abilityToUse = abilitiesThatCanLevelCommon[Random.Range(0, abilitiesThatCanLevelCommon.Count)];
                abilitiesThatCanLevelCommon.Remove(abilityToUse);
                break;
            case RarityTypes.Uncommon:
                abilityToUse = abilitiesThatCanLevelUncommon[Random.Range(0, abilitiesThatCanLevelUncommon.Count)];
                abilitiesThatCanLevelUncommon.Remove(abilityToUse);
                break;
            case RarityTypes.Rare:
                abilityToUse = abilitiesThatCanLevelRare[Random.Range(0, abilitiesThatCanLevelRare.Count)];
                abilitiesThatCanLevelRare.Remove(abilityToUse);
                break;
            case RarityTypes.Epic:
                abilityToUse = abilitiesThatCanLevelEpic[Random.Range(0, abilitiesThatCanLevelEpic.Count)];
                abilitiesThatCanLevelEpic.Remove(abilityToUse);
                break;
            case RarityTypes.Legendary:
                abilityToUse = abilitiesThatCanLevelLegendary[Random.Range(0, abilitiesThatCanLevelLegendary.Count)];
                abilitiesThatCanLevelLegendary.Remove(abilityToUse);
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
        AddBaseDamage();
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
