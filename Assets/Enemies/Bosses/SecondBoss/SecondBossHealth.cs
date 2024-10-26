using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SecondBossHealth", menuName = "ScriptableObjects/Bosses/SecondBossHealth")]
public class SecondBossHealth : ScriptableObject
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int health = 10;

    public void ResetHealth()
    {
        health = maxHealth;
    }

    public void TakeDamage()
    {
        health -= 1;
    }

    public int GetHealth()
    {
        return health;
    }
}
