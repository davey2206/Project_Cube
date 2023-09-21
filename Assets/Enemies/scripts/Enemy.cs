using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float Health;
    [SerializeField] Transform HealthBar;
    [SerializeField] GameObject DieEffect;
    [SerializeField] abilitiesObject abilities;
    [SerializeField] int xpDrop;
    Leveling leveling;

    bool Stunned;
    float StunTime;

    Vector3 Velocity;
    float maxHealth;
    bool isDead;
    private void Start()
    {
        maxHealth = Health;
        isDead = false;
        CheckOverlap();

        leveling = GameObject.Find("Player").GetComponent<Leveling>();
    }

    private void Update()
    {
        float size = Health / maxHealth;
        if (size < 0)
        {
            size = 0;
        }
        HealthBar.localScale = Vector3.SmoothDamp(HealthBar.localScale, new Vector3(size, size, size), ref Velocity, 20 * Time.deltaTime);
        if (!isDead && !Stunned)
        {
            var step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, step);
        }
        if (isDead)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, Vector3.zero, ref Velocity, 20 * Time.deltaTime);
        }

        CheckIfStunned();
    }

    public void HitPlayer()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        Health = Health - damage;
        if (Health <= 0)
        {

            leveling.addXp(GetXpDrop());
            isDead = true;
            GetComponent<BoxCollider>().enabled = false;
            Instantiate(DieEffect, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
            ActivateAbilities();
            Destroy(gameObject, 0.5f);
        }
    }

    public void ActivateAbilities()
    {
        foreach (var abilitie in abilities.abilities)
        {
            if (abilitie.abilityType == AbilityTypes.EnemyDeath && abilitie.Active == true)
            {
                abilitie.Ability.Invoke(abilitie.Level, transform.position);
            }
        }
    }

    public void CheckOverlap()
    {
        int counter = 0;
        Physics.SyncTransforms();
        Vector3 posRightTop = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, (transform.localScale * 1.2f), Quaternion.identity);

        foreach (var hit in hitColliders)
        {
            if (hit.CompareTag("Enemy"))
            {
                counter++;
            }
        }

        if (counter >= 2)
        {
            switch (Random.Range(1,5))
            {
                case 1:
                    transform.position = new Vector3(Random.Range(posRightTop.x, -posRightTop.x), 0, posRightTop.z + Random.Range(1f, 5f));
                    break;
                case 2:
                    transform.position = new Vector3(Random.Range(posRightTop.x, -posRightTop.x), 0, -posRightTop.z - Random.Range(1f, 5f));
                    break;
                case 3:
                    transform.position = new Vector3(posRightTop.x + Random.Range(1f, 5f), 0, Random.Range(posRightTop.z, -posRightTop.z));
                    break;
                case 4:
                    transform.position = new Vector3(-posRightTop.x - Random.Range(1f, 5f), 0, Random.Range(posRightTop.x, -posRightTop.x));
                    break;
            }
            CheckOverlap();
        }
    }

    public void Stun(float stunTime)
    {
        StunTime = StunTime + stunTime;
        Stunned = true;
    }

    public void CheckIfStunned()
    {
        StunTime = StunTime - Time.deltaTime;
        if (StunTime <= 0)
        {
            StunTime = 0;
            Stunned = false;
        }
    }

    public int GetXpDrop()
    {
        return xpDrop;
    }
}
