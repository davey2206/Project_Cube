using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ShieldEffect : MonoBehaviour
{
    [SerializeField] VisualEffect visualEffect;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] ability ability;

    public int MaxNumberOfShields;
    public float RegenTime;
    bool evolved = false;
    int level;

    public void LevelUp(int n, float r, int l)
    {
        MaxNumberOfShields = n;
        RegenTime = r;
        level = l;

        playerStats.Shields = MaxNumberOfShields;

        StopAllCoroutines();
        StartCoroutine(Regen());
    }

    private void Update()
    {
        if (ability.Evolved && !evolved)
        {
            evolved = true;
            switch (level)
            {
                case 1:
                    MaxNumberOfShields = 4;
                    break;
                case 2:
                    MaxNumberOfShields = 5;
                    break;
                case 3:
                    MaxNumberOfShields = 7;
                    break;
                case 4:
                    MaxNumberOfShields = 8;
                    break;
                case 5:
                    MaxNumberOfShields = 10;
                    break;
            }
        }

        if (playerStats.Shields != visualEffect.GetInt("NumberOfShields"))
        {
            visualEffect.SetInt("NumberOfShields", playerStats.Shields);

            visualEffect.Reinit();
        }
    }

    IEnumerator Regen()
    {
        while (true)
        {
            if (playerStats.Shields != MaxNumberOfShields)
            {
                playerStats.Shields++;
            }

            yield return new WaitForSeconds(RegenTime);
        }
    }
}
