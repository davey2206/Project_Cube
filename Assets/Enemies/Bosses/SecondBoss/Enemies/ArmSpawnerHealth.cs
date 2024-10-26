using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ArmSpawnerHealth : MonoBehaviour
{
    [SerializeField] float Health;
    [SerializeField] Transform HealthBar;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] SecondBossHealth bossHealth;

    [Header("UI")]
    [SerializeField] DamageNumbers damageNumbers;

    [Header("Effects")]
    [SerializeField] GameObject DieEffect;

    Vector3 Velocity;
    float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        float size = Health / maxHealth;
        if (size < 0)
        {
            size = 0;
        }
        HealthBar.localScale = Vector3.SmoothDamp(HealthBar.localScale, new Vector3(size, size, size), ref Velocity, 20 * Time.deltaTime);
    }

    public void TakeDamage(float damage, ColorEnum color)
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + Random.Range(-1f, 1f));
        bool crit = false;

        if (playerStats.crit())
        {
            damage = playerStats.GetCritDamage(damage);
            Health = Health - damage;
            DamageNumbers numbers = Instantiate(damageNumbers, pos, Quaternion.identity);
            numbers.ShowDamage(damage);
            numbers.Crit();
            crit = true;
        }
        else
        {
            Health = Health - damage;
            DamageNumbers numbers = Instantiate(damageNumbers, pos, Quaternion.identity);
            numbers.ShowDamage(damage);
        }

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        bossHealth.TakeDamage();
        Instantiate(DieEffect, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
        Destroy(gameObject, 0.5f);
    }
}
