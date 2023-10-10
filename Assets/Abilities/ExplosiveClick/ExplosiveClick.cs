using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveClick : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] WaveAttacks Wave;

    public void Ability(int level, Vector3 pos)
    {
        float baseAttack = playerStats.GetBlueAttack();
        WaveAttacks wave;

        switch (level)
        {
            case 1:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                wave.SetStats(playerStats.GetAttack() * 0.25f, 3, true);
                break;
            case 2:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                wave.SetStats(playerStats.GetAttack() * 0.25f, 5, true);
                break;
            case 3:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                wave.SetStats(playerStats.GetAttack() * 0.50f, 5, true);
                break;
            case 4:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                wave.SetStats(playerStats.GetAttack() * 0.50f, 8, true);
                break;
            case 5:
                wave = Instantiate(Wave, pos, Quaternion.identity);
                wave.SetStats(playerStats.GetAttack() * 0.75f, 8, true);
                break;
        }
    }
}
