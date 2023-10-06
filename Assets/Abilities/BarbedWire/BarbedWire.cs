using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbedWire : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] WaveAttacks Wave;

    public void Ability(int level, Vector3 pos)
    {
        float baseAttack = playerStats.GetAttack();
        WaveAttacks wave;

        switch (level)
        {
            case 1:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                wave.SetStats(playerStats.GetAttack());
                break;
            case 2:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                wave.SetStats(playerStats.GetAttack() * 1.25f);
                break;
            case 3:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                wave.SetStats(playerStats.GetAttack() * 1.5f);
                break;
            case 4:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                wave.SetStats(playerStats.GetAttack() * 2f);
                break;
            case 5:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                wave.SetStats(playerStats.GetAttack() * 2.5f);
                break;
        }
    }
}
