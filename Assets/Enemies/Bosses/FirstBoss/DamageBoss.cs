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
    [SerializeField] GameObject ShieldWhiteBrakeVFX;
    [SerializeField] GameObject ShieldYellowBrakeVFX;
    [SerializeField] GameObject ShieldBlueBrakeVFX;
    [SerializeField] GameObject ShieldGreenBrakeVFX;

    [Header("Shield")]
    [SerializeField] GameObject ShieldWhite;
    [SerializeField] GameObject ShieldYellow;
    [SerializeField] GameObject ShieldBlue;
    [SerializeField] GameObject ShieldGreen;

    private ColorEnum ShieldColor;

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

    public void TakeDamage(float damage, ColorEnum color)
    {
        if (ShieldWhite.activeInHierarchy)
        {
            if (color == ShieldColor)
            {
                ShieldWhite.SetActive(false);
                Instantiate(ShieldWhiteBrakeVFX, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
            }
        }
        else if (ShieldYellow.activeInHierarchy)
        {
            if (color == ShieldColor)
            {
                ShieldYellow.SetActive(false);
                Instantiate(ShieldYellowBrakeVFX, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
            }
        }
        else if (ShieldBlue.activeInHierarchy)
        {
            if (color == ShieldColor)
            {
                ShieldBlue.SetActive(false);
                Instantiate(ShieldBlueBrakeVFX, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
            }
        }
        else if (ShieldGreen.activeInHierarchy)
        {
            if (color == ShieldColor)
            {
                ShieldGreen.SetActive(false);
                Instantiate(ShieldGreenBrakeVFX, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
            }
        }
        else
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
    }

    public void Die()
    {
        GetComponent<BoxCollider>().enabled = false;
        gameObject.SetActive(false);
    }
}
