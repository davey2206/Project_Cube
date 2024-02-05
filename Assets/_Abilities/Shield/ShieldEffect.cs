using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ShieldEffect : MonoBehaviour
{
    [SerializeField] VisualEffect visualEffect;
    [SerializeField] PlayerStats playerStats;

    public int MaxNumberOfShields;
    public float RegenTime;

    public void LevelUp(int n, float r)
    {
        MaxNumberOfShields = n;
        RegenTime = r;

        playerStats.Shields = MaxNumberOfShields;

        StopAllCoroutines();
        StartCoroutine(Regen());
    }

    private void Update()
    {
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
