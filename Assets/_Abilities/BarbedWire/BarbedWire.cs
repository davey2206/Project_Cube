using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbedWire : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] WaveAttacks Wave;
    [SerializeField] GameObject SFX;
    [SerializeField] AudioManeger audioManeger;
    [SerializeField] ability ability;

    public void Ability(int level, Vector3 pos)
    {
        float damage = playerStats.GetAttack();
        WaveAttacks wave;

        switch (level)
        {
            case 1:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                if (ability.Evolved)
                {
                    wave.SetStats(0.01f, damage + playerStats.GetAbilityDamage(damage), 12, true);
                }
                else
                {
                    wave.SetStats(0.01f, damage + playerStats.GetAbilityDamage(damage));
                }
                if (audioManeger.CanSpawnAudio())
                {
                    Instantiate(SFX, pos, Quaternion.identity);
                }
                break;
            case 2:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                damage = playerStats.GetAttack() * 1.25f;
                if (ability.Evolved)
                {
                    wave.SetStats(0.01f, damage + playerStats.GetAbilityDamage(damage), 14, true);
                }
                else
                {
                    wave.SetStats(0.01f, damage + playerStats.GetAbilityDamage(damage));
                }
                if (audioManeger.CanSpawnAudio())
                {
                    Instantiate(SFX, pos, Quaternion.identity);
                }
                break;
            case 3:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                damage = playerStats.GetAttack() * 1.5f;
                if (ability.Evolved)
                {
                    wave.SetStats(0.01f, damage + playerStats.GetAbilityDamage(damage), 16, true);
                }
                else
                {
                    wave.SetStats(0.01f, damage + playerStats.GetAbilityDamage(damage));
                }
                if (audioManeger.CanSpawnAudio())
                {
                    Instantiate(SFX, pos, Quaternion.identity);
                }
                break;
            case 4:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                damage = playerStats.GetAttack() * 2f;
                if (ability.Evolved)
                {
                    wave.SetStats(0.01f, damage + playerStats.GetAbilityDamage(damage), 18, true);
                }
                else
                {
                    wave.SetStats(0.01f, damage + playerStats.GetAbilityDamage(damage));
                }
                if (audioManeger.CanSpawnAudio())
                {
                    Instantiate(SFX, pos, Quaternion.identity);
                }
                break;
            case 5:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                damage = playerStats.GetAttack() * 2.5f;
                if (ability.Evolved)
                {
                    wave.SetStats(0.01f, damage + playerStats.GetAbilityDamage(damage), 20, true);
                }
                else
                {
                    wave.SetStats(0.01f, damage + playerStats.GetAbilityDamage(damage));
                }
                if (audioManeger.CanSpawnAudio())
                {
                    Instantiate(SFX, pos, Quaternion.identity);
                }
                break;
        }
    }
}
