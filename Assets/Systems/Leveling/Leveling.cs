using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Leveling : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] int Level;
    [SerializeField] int xp;
    [SerializeField] public AnimationCurve xpNeededPerLevel;
    [SerializeField] abilitiesObject abilities;
    [SerializeField] abilitiesObject extraAbilities;
    [SerializeField] PlayerStats playerStats;

    //UI
    [Header("XP Bar")]
    [SerializeField] Slider xpBar;
    [SerializeField] TextMeshProUGUI levelText;


    [Header("AbilitySelect")]
    [SerializeField] GameObject Spawner;
    [SerializeField] GameObject SpawnPoint_1;
    [SerializeField] GameObject SpawnPoint_2;
    [SerializeField] GameObject SpawnPoint_3;


    float Velocity;
    int excesXP = 0;
    bool IsLeveling;
    List<int> NumbersUsed = new List<int>();

    List<ability> abilitiesCommon = new List<ability>();
    List<ability> abilitiesUncommon = new List<ability>();
    List<ability> abilitiesRare = new List<ability>();
    List<ability> abilitiesEpic = new List<ability>();
    List<ability> abilitiesLegendary = new List<ability>();

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

        excesXP = 0;
        excesXP = xp - (int)xpNeededPerLevel.Evaluate(Level);

        if (xp >= (int)xpNeededPerLevel.Evaluate(Level) && !IsLeveling && playerStats.alive)
        {
            IsLeveling = true;
            StartCoroutine(TimeStop());
        }
    }

    public void LevelUp(bool isReroll)
    {
        SortExtraAbilities();

        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    SpawnCard(SpawnPoint_1.transform);
                    break;
                case 1:
                    SpawnCard(SpawnPoint_2.transform);
                    break;
                case 2:
                    SpawnCard(SpawnPoint_3.transform);
                    break;
            }
        }

        NumbersUsed.Clear();

        if (!isReroll)
        {
            Spawner.GetComponent<ResetCards>().Spawn();
        }

        resetXp();
    }

    private void SpawnCard(Transform location)
    {
        ability AbilityToUse;
        int abilityOrStat = Random.Range(0, 2);

        List<ability> a = new List<ability>();
        a = GetAbilities();

        if (abilityOrStat == 0 && a.Count != 0)
        {
            int rng = GetRandomAbility(a);
            AbilityToUse = a[rng];

            GameObject Card = Instantiate(AbilityToUse.Card[AbilityToUse.Level], location);
            Card.GetComponentInChildren<LevelAbility>().Ability = AbilityToUse;
        }
        else
        {
            AbilityToUse = GetExtraAbilities();
            GameObject Card1 = Instantiate(AbilityToUse.Card[AbilityToUse.Level], location);
            Card1.GetComponentInChildren<LevelAbility>().Ability = AbilityToUse;
        }
    }

    private int GetRandomAbility(List<ability> a)
    {
        int rng = 0;
        bool canUse = false;

        while (!canUse)
        {
            rng = Random.Range(0, a.Count);
            canUse = true;

            foreach (var usedNumber in NumbersUsed)
            {
                if (usedNumber == rng)
                {
                    canUse = false;
                }
            }
        }
        NumbersUsed.Add(rng);
        return rng;
    }

    public List<ability> GetAbilities()
    {
        List<ability> a = new List<ability>();

        foreach (var Ability in abilities.abilities)
        {
            if (Ability.Unlocked && Ability.Level < 5)
            {
                a.Add(Ability);
            }
        }

        return a;
    }

    public ability GetExtraAbilities()
    {
        ability a = null;
        float rng = Random.Range(0,100);
        rng = rng + playerStats.Luck;

        if (rng < 44)
        {
            a = abilitiesCommon[Random.Range(0, abilitiesCommon.Count)];
            abilitiesCommon.Remove(a);
        }
        else if (rng >= 40 && rng < 74)
        {
            a = abilitiesUncommon[Random.Range(0, abilitiesUncommon.Count)];
            abilitiesUncommon.Remove(a);
        }
        else if (rng >= 74 && rng < 89)
        {
            a = abilitiesRare[Random.Range(0, abilitiesRare.Count)];
            abilitiesRare.Remove(a);
        }
        else if (rng >= 89 && rng < 99)
        {
            a = abilitiesEpic[Random.Range(0, abilitiesEpic.Count)];
            abilitiesEpic.Remove(a);
        }
        else if (rng >= 99)
        {
            a = abilitiesLegendary[Random.Range(0, abilitiesLegendary.Count)];
            abilitiesLegendary.Remove(a);
        }

        if (GetComponent<Player>().canHeal() == false && a.Name == "Heal")
        {
            a = GetExtraAbilities();
        }

        return a;
    }

    public void SortExtraAbilities()
    {
        abilitiesCommon.Clear();
        abilitiesUncommon.Clear();
        abilitiesRare.Clear();
        abilitiesEpic.Clear();
        abilitiesLegendary.Clear();

        foreach (var Ability in extraAbilities.abilities)
        {
            if (Ability.rarity == RarityTypes.Common)
            {
                abilitiesCommon.Add(Ability);
            }
        }

        foreach (var Ability in extraAbilities.abilities)
        {
            if (Ability.rarity == RarityTypes.Uncommon)
            {
                abilitiesUncommon.Add(Ability);
            }
        }

        foreach (var Ability in extraAbilities.abilities)
        {
            if (Ability.rarity == RarityTypes.Rare)
            {
                abilitiesRare.Add(Ability);
            }
        }

        foreach (var Ability in extraAbilities.abilities)
        {
            if (Ability.rarity == RarityTypes.Epic)
            {
                abilitiesEpic.Add(Ability);
            }
        }

        foreach (var Ability in extraAbilities.abilities)
        {
            if (Ability.rarity == RarityTypes.Legendary)
            {
                abilitiesLegendary.Add(Ability);
            }
        }
    }

    public void AddBaseDamage()
    {
        if (Level < 3)
        {
            playerStats.BaseAttack = playerStats.BaseAttack + 0.2f;
        }
        else if (Level % 5 == 0)
        {
            playerStats.BaseAttack = playerStats.BaseAttack + 0.1f;
        }
    }

    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(0.5f);
        AddBaseDamage();
        LevelUp(false);
        yield return new WaitForEndOfFrame();
        Time.timeScale = 0;
    }

    public void resetXp()
    {
        Level++;
        levelText.text = Level.ToString();
        xp = 0 + excesXP;
        IsLeveling = false;
    }
}
