using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoss : MonoBehaviour
{
    [SerializeField] float Health;
    [SerializeField] Transform HealthBar;

    [Header("UI")]
    [SerializeField] DamageNumbers damageNumbers;

    [Header("Effects")]
    [SerializeField] GameObject HitSFX;
    [SerializeField] GameObject DieVFX;

    float maxHealth; 
    Vector3 Velocity;

    private void Start()
    {
        maxHealth = Health;
    }

    void Update()
    {
        float size = Health / maxHealth;
        if (size < 0)
        {
            size = 0;
        }
        HealthBar.localScale = Vector3.SmoothDamp(HealthBar.localScale, new Vector3(size, size, size), ref Velocity, 20 * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        Health = Health - damage;

        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + Random.Range(-1f, 1f));

        DamageNumbers numbers = Instantiate(damageNumbers, pos, Quaternion.identity);
        numbers.ShowDamage(damage);


        if (Health <= 0)
        {
            Die();
            Instantiate(DieVFX, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(HitSFX, transform.position, Quaternion.identity);
        }
    }

    public void Die()
    {
        GetComponent<BoxCollider>().enabled = false;
        gameObject.SetActive(false);
    }
}
