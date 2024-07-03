using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] public int Cost;
    [SerializeField] bool checkOverlap;

    [Header("Stats")]
    [SerializeField] float Speed;
    [SerializeField] float Health;
    [SerializeField] Transform HealthBar;
    [SerializeField] GameObject Shield;
    [SerializeField] ColorEnum ShieldColor;
    [SerializeField] abilitiesObject abilities;

    [Header("Effects")]
    [SerializeField] GameObject DieEffect;
    [SerializeField] GameObject HitSFX;
    [SerializeField] GameObject DieSFX;
    [SerializeField] GameObject ShieldBrakeVFX;
    [SerializeField] AudioManeger audioManeger;
    [SerializeField] Animator animator;
    [SerializeField] Collider BoxCollider;

    [Header("Drops")]
    [SerializeField] PlayerStats playerStats;
    [SerializeField] int xpDrop;
    [SerializeField] GameObject xpEffect;
    [SerializeField] int coinDrop;
    [Range(0,100)]
    [SerializeField] int dropRate;
    [SerializeField] GameObject coinEffect;

    [Header("UI")]
    [SerializeField] DamageNumbers damageNumbers;

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
        if (checkOverlap)
        {
            StartCoroutine(CheckOverlap());
        }

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

    public void TakeDamage(float damage, ColorEnum color)
    {
        if (Shield.activeInHierarchy)
        {
            if (color == ShieldColor)
            {
                Shield.SetActive(false);
                Instantiate(ShieldBrakeVFX, new Vector3(transform.position.x ,transform.position.y + 2f, transform.position.z), Quaternion.identity);
            }
        }
        else
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
            else
            {
                if (crit)
                {
                    animator.SetTrigger("Crit");
                }
                else
                {
                    animator.SetTrigger("Hit");
                }
                if (audioManeger.CanSpawnAudio())
                {
                    Instantiate(HitSFX, transform.position, Quaternion.identity);
                }
            }
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
                        transform.position = new Vector3(Random.Range(posRightTop.x, -posRightTop.x), 0, posRightTop.z + Random.Range(1.5f, maxPost));
                        break;
                    case 2:
                        transform.position = new Vector3(Random.Range(posRightTop.x, -posRightTop.x), 0, -posRightTop.z - Random.Range(1.5f, maxPost));
                        break;
                    case 3:
                        transform.position = new Vector3(posRightTop.x + Random.Range(1.5f, maxPost), 0, Random.Range(posRightTop.z, -posRightTop.z));
                        break;
                    case 4:
                        transform.position = new Vector3(-posRightTop.x - Random.Range(1.5f, maxPost), 0, Random.Range(posRightTop.x, -posRightTop.x));
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
        animator.SetTrigger("Die");
        StartCoroutine(XpDrop());
        StartCoroutine(CoinDrop());
        isDead = true;
        BoxCollider.enabled = false;
        if (audioManeger.CanSpawnAudio())
        {
            Instantiate(DieSFX, transform.position, Quaternion.identity);
        }
        Instantiate(DieEffect, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
        ActivateAbilities();
        Destroy(gameObject, 0.5f);
    }

    public IEnumerator XpDrop()
    {
        if (playerStats.alive)
        {
            var Effect = Instantiate(xpEffect, transform.position, Quaternion.identity);
            Effect.GetComponent<VisualEffect>().SetInt("Number", xpDrop);
            yield return new WaitForSeconds(0.4f);
            leveling.addXp(xpDrop);
        }
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
