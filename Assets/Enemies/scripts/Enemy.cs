using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] public Vector2 difficultyRange;
    [SerializeField] public int Cost;

    [Header("Stats")]
    [SerializeField] float Speed;
    [SerializeField] float Health;
    [SerializeField] Transform HealthBar;
    [SerializeField] GameObject DieEffect;
    [SerializeField] abilitiesObject abilities;

    [Header("Drops")]
    [SerializeField] PlayerStats playerStats;
    [SerializeField] int xpDrop;
    [SerializeField] GameObject xpEffect;
    [SerializeField] int coinDrop;
    [Range(0,100)]
    [SerializeField] int dropRate;
    [SerializeField] GameObject coinEffect;

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
        StartCoroutine(CheckOverlap());

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
            Die();
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

    public IEnumerator CheckOverlap()
    {
        int NumberOfTimes = 0;
        int maxPost = 1;
        int counter = 2;
        while (counter >= 2)
        {
            counter = 0;
            yield return new WaitForFixedUpdate();

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
                switch (Random.Range(1, 5))
                {
                    case 1:
                        transform.position = new Vector3(Random.Range(posRightTop.x, -posRightTop.x), 0, posRightTop.z + Random.Range(1f, maxPost));
                        break;
                    case 2:
                        transform.position = new Vector3(Random.Range(posRightTop.x, -posRightTop.x), 0, -posRightTop.z - Random.Range(1f, maxPost));
                        break;
                    case 3:
                        transform.position = new Vector3(posRightTop.x + Random.Range(1f, maxPost), 0, Random.Range(posRightTop.z, -posRightTop.z));
                        break;
                    case 4:
                        transform.position = new Vector3(-posRightTop.x - Random.Range(1f, maxPost), 0, Random.Range(posRightTop.x, -posRightTop.x));
                        break;
                }
            }

            NumberOfTimes++;
            if (NumberOfTimes == 10)
            {
                maxPost++;
                NumberOfTimes = 0;
            }
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

    public void Die()
    {
        GetComponent<Animator>().SetTrigger("Die");
        StartCoroutine(XpDrop());
        StartCoroutine(CoinDrop());
        isDead = true;
        GetComponent<BoxCollider>().enabled = false;
        Instantiate(DieEffect, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
        ActivateAbilities();
        Destroy(gameObject, 0.5f);
    }

    public IEnumerator XpDrop()
    {
        var Effect = Instantiate(xpEffect, transform.position, Quaternion.identity);
        Effect.GetComponent<VisualEffect>().SetInt("Number", xpDrop);
        yield return new WaitForSeconds(0.4f);
        leveling.addXp(xpDrop);
    }

    public IEnumerator CoinDrop()
    {
        if (Random.Range(0,101) < dropRate)
        {
            var Effect = Instantiate(coinEffect, transform.position, Quaternion.identity);
            Effect.GetComponent<VisualEffect>().SetInt("Number", coinDrop);
            yield return new WaitForSeconds(0.4f);
            playerStats.Coins += coinDrop;
        }
    }
}
