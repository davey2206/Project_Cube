using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Charger : MonoBehaviour
{
    [SerializeField] List<Transform> HealthBars;
    [SerializeField] ChargeCubeMovement ChargeCube;
    [SerializeField] Transform Target;
    [SerializeField] float SpawnDelay = 5;
    [SerializeField] float MaxHealth;

    [SerializeField] Vector3 position;
    [SerializeField] Vector3 rotation;

    [Header("Damage")]
    [SerializeField] DamageNumbers damageNumbers;
    [SerializeField] PlayerStats playerStats;

    float health;
    Vector3 Velocity;
    Vector3 Velocity_1;
    Vector3 Velocity_2;

    private void OnEnable()
    {
        StartCoroutine(Spawn());
        health = MaxHealth;
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnDelay);
            ChargeCubeMovement cube = Instantiate(ChargeCube, transform.position, Quaternion.identity);
            cube.SetTarget(Target);
        }
    }

    private void Update()
    {
        transform.position = position;
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

        float size = health / MaxHealth;
        if (size < 0)
        {
            size = 0;
        }
        HealthBars[0].localScale = Vector3.SmoothDamp(HealthBars[0].localScale, new Vector3(size, size, size), ref Velocity, 20 * Time.deltaTime);
        HealthBars[1].localScale = Vector3.SmoothDamp(HealthBars[1].localScale, new Vector3(size, size, size), ref Velocity_1, 20 * Time.deltaTime);
        HealthBars[2].localScale = Vector3.SmoothDamp(HealthBars[2].localScale, new Vector3(size, size, size), ref Velocity_2, 20 * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + Random.Range(-1f, 1f));

        if (playerStats.crit())
        {
            damage = playerStats.GetCritDamage(damage);
            health = health - damage;
            DamageNumbers numbers = Instantiate(damageNumbers, pos, Quaternion.identity);
            numbers.ShowDamage(damage);
            numbers.Crit();
        }
        else
        {
            health = health - damage;
            DamageNumbers numbers = Instantiate(damageNumbers, pos, Quaternion.identity);
            numbers.ShowDamage(damage);
        }

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
