using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunTurretSpawn : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] MiniGunTurret Turret;

    public void Ability(int level, Vector3 pos)
    {
        float baseAttack = playerStats.GetAttack();
        pos = new Vector3(pos.x + Random.Range(-0.5f, 0.5f), pos.y, pos.z + Random.Range(-0.5f, 0.5f));
        switch (level)
        {
            case 1:
                SpawnTurret(pos, 10, baseAttack * 0.1f);
                break;
            case 2:
                SpawnTurret(pos, 10, baseAttack * 0.2f);
                break;
            case 3:
                SpawnTurret(pos, 12, baseAttack * 0.2f);
                break;
            case 4:
                SpawnTurret(pos, 12, baseAttack * 0.3f);
                break;
            case 5:
                SpawnTurret(pos, 15, baseAttack * 0.3f);
                break;
        }
    }

    public void SpawnTurret(Vector3 pos, float lifespan, float attack)
    {
        if (Random.Range(0, 101) < 10 + playerStats.Luck)
        {
            MiniGunTurret turret = Instantiate(Turret, pos, Quaternion.identity);
            turret.Stats(lifespan, attack);
        }
    }
}
