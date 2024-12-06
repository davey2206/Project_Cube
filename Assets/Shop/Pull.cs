using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pull : MonoBehaviour
{
    [SerializeField] List<OneTimeBuffs> Buffs;
    [SerializeField] List<Material> Materials;
    [SerializeField] PlayerStats Stats;
    [SerializeField] SaveFile Save;
    [SerializeField] MeshRenderer WinCube;
    [SerializeField] Animator animator;
    [SerializeField] Button button;

    public void Summon()
    {
        if (Save.coins >= 250)
        {
            Save.coins = Save.coins - 250;
            animator.SetTrigger("Open");
            int rng = Random.Range(0, 25);

            if (rng == 1 && checkSkins())
            {
                WinCube.SetMaterials(Skin());
            }
            else
            {
                WinCube.SetMaterials(Buff());
            }

            StartCoroutine(ButtonDelay());
        }
    }

    private List<Material> Skin()
    {
        List<Material> mats = new List<Material>();
        int rng = Random.Range(0, Materials.Count);

        while (Save.Skins[rng])
        {
            rng = Random.Range(0, Materials.Count);
        }

        mats.Add(Materials[rng]);

        StartCoroutine(SkinDelay(rng));

        return mats;
    }

    private List<Material> Buff()
    {
        List<Material> mats = new List<Material>();
        int rng = Random.Range(1, Buffs.Count);

        switch (rng)
        {
            case 1:
                OneTimeBuffs buff_1 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                buff_1 = Buffs[0];
                StartCoroutine(BuffDelay(buff_1));
                mats.Add(Buffs[0].Mat);
                break;
            case 2:
                OneTimeBuffs buff_2 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                buff_2 = Buffs[1];
                StartCoroutine(BuffDelay(buff_2));
                mats.Add(Buffs[1].Mat);
                break;
            case 3:
                OneTimeBuffs buff_3 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                buff_3 = Buffs[2];
                StartCoroutine(BuffDelay(buff_3));
                mats.Add(Buffs[2].Mat);
                break;
            case 4:
                OneTimeBuffs buff_4 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                buff_4 = Buffs[3];
                StartCoroutine(BuffDelay(buff_4));
                mats.Add(Buffs[3].Mat);
                break;
            case 5:
                OneTimeBuffs buff_5 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                buff_5 = Buffs[4];
                StartCoroutine(BuffDelay(buff_5));
                mats.Add(Buffs[4].Mat);
                break;
            case 6:
                OneTimeBuffs buff_6 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                buff_6 = Buffs[5];
                StartCoroutine(BuffDelay(buff_6));
                mats.Add(Buffs[5].Mat);
                break;
            case 7:
                OneTimeBuffs buff_7 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                buff_7 = Buffs[6];
                StartCoroutine(BuffDelay(buff_7));
                mats.Add(Buffs[6].Mat);
                break;
            case 8:
                OneTimeBuffs buff_8 = ScriptableObject.CreateInstance<OneTimeBuffs>();
                buff_8 = Buffs[7];
                StartCoroutine(BuffDelay(buff_8));
                mats.Add(Buffs[8].Mat);
                break;
        }

        return mats;
    }

    public bool checkSkins()
    {
        bool CanSummon = false;
        foreach (var skin in Save.Skins)
        {
            if (!skin)
            {
                CanSummon = true;
            }
        }
        return CanSummon;
    }

    IEnumerator BuffDelay(OneTimeBuffs buff)
    {
        yield return new WaitForSeconds(1.1f);
        Stats.Buffs.Add(buff);
        Save.Buffs.Add(buff.GetStatType());
        GameObject.Find("SaveSystem").GetComponent<SaveSystem>().SaveGame();
    }
    IEnumerator SkinDelay(int skin)
    {
        yield return new WaitForSeconds(1.1f);
        Save.Skins[skin] = true;
        GameObject.Find("SaveSystem").GetComponent<SaveSystem>().SaveGame();
    }

    IEnumerator ButtonDelay()
    {
        button.enabled = false;
        yield return new WaitForSeconds(5f);
        button.enabled = true;
    }
}
