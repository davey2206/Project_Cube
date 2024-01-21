using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbedWire : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] WaveAttacks Wave;
    [SerializeField] GameObject SFX;
    [SerializeField] AudioManeger audioManeger;

    public void Ability(int level, Vector3 pos)
    {
        float damage = playerStats.GetAttack();
        WaveAttacks wave;

        switch (level)
        {
            case 1:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                wave.SetStats(damage + playerStats.GetAbilityDamage(damage));
                if (audioManeger.CanSpawnAudio())
                {
                    Instantiate(SFX, pos, Quaternion.identity);
                }
                break;
            case 2:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                damage = playerStats.GetAttack() * 1.25f;
                wave.SetStats(damage + playerStats.GetAbilityDamage(damage));
                if (audioManeger.CanSpawnAudio())
                {
                    Instantiate(SFX, pos, Quaternion.identity);
                }
                break;
            case 3:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                damage = playerStats.GetAttack() * 1.5f;
                wave.SetStats(damage + playerStats.GetAbilityDamage(damage));
                if (audioManeger.CanSpawnAudio())
                {
                    Instantiate(SFX, pos, Quaternion.identity);
                }
                break;
            case 4:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                damage = playerStats.GetAttack() * 2f;
                wave.SetStats(damage + playerStats.GetAbilityDamage(damage));
                if (audioManeger.CanSpawnAudio())
                {
                    Instantiate(SFX, pos, Quaternion.identity);
                }
                break;
            case 5:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                damage = playerStats.GetAttack() * 2.5f;
                wave.SetStats(damage + playerStats.GetAbilityDamage(damage));
                if (audioManeger.CanSpawnAudio())
                {
                    Instantiate(SFX, pos, Quaternion.identity);
                }
                break;
        }
    }
}
