using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawn : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Turret Turret;
    [SerializeField] Turret TurretEvolved;
    [SerializeField] ability ability;

    public void Ability(int level, Vector3 pos)
    {
        float baseAttack = playerStats.GetAttack();
        pos = new Vector3(pos.x + Random.Range(-0.5f, 0.5f), pos.y, pos.z + Random.Range(-0.5f, 0.5f));
        switch (level)
        {
            case 1:
                SpawnTurret(pos, 5, baseAttack * 0.5f);
                break;
            case 2:
                SpawnTurret(pos, 5, baseAttack * 0.75f);
                break;
            case 3:
                SpawnTurret(pos, 8, baseAttack * 0.75f);
                break;
            case 4:
                SpawnTurret(pos, 8, baseAttack * 1f);
                break;
            case 5:
                SpawnTurret(pos, 10, baseAttack * 1f);
                break;
        }
    }

    public void SpawnTurret(Vector3 pos, float lifespan, float attack)
    {
        if (Random.Range(0, 101) < 10)
        {
            Turret turret = null;
            if (ability.Evolved)
            {
                turret = Instantiate(TurretEvolved, pos, Quaternion.identity);
            }
            else
            {
                turret = Instantiate(Turret, pos, Quaternion.identity);
            }
            turret.Stats(lifespan, attack);
        }
    }
}
