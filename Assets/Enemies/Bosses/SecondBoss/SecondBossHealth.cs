using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SecondBossHealth", menuName = "ScriptableObjects/Bosses/SecondBossHealth")]
public class SecondBossHealth : ScriptableObject
{
    [SerializeField] float maxHealth = 10;
    [SerializeField] float health = 10;

    public void ResetHealth()
    {
        health = maxHealth;
    }

    public void TakeDamage()
    {
        health -= 1;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
