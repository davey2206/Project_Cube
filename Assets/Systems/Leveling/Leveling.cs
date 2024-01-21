using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    private void Start()
    {
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

    public void LevelUp(bool ability)
    {
        
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

    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(0.5f);
        AddBaseDamage();
        if (gainAbiltiy)
        {
            buttons.SetActive(true);
            yield return new WaitForEndOfFrame();
            LevelUp(true);
            gainAbiltiy = !gainAbiltiy;
        }
        else
        {
            buttonsStats.SetActive(true);
            yield return new WaitForEndOfFrame();
            LevelUp(false);
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
