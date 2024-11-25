using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdBoss : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] Transform Boss;
    [SerializeField] Transform HealthBar;
    [SerializeField] GameObject Charger;
    [SerializeField] GameObject Charger_1;
    [SerializeField] GameObject Charger_2;
    [SerializeField] GameObject Charger_3;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] GameObject Enemy;
    [SerializeField] Transform Arm_L;
    [SerializeField] Transform Arm_R;
    [SerializeField] Animator animator;

    [Header("Stats")]
    [SerializeField] float MaxCharge;
    [SerializeField] float MaxHealth;

    float Charge;
    float health;
    int count = 0;
    bool isLeft;
    bool canMove = false;
    Vector3 Velocity;
    Vector3 Velocity_2;
    Vector3 Velocity_3;

    private IEnumerator Start()
    {
        health = MaxHealth;

        yield return new WaitForSeconds(2);
        canMove = true;
        StartCoroutine(BossLoop());
        StartCoroutine(MoveDiraction());
    }

    private void Update()
    {
        if (canMove)
        {
            Move();
        }
        UpdateHealth();
        UpdateCharge();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            //Instantiate(DeadVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void UpdateHealth()
    {
        float size = health / MaxHealth;
        if (size < 0)
        {
            size = 0;
        }
        HealthBar.localScale = Vector3.SmoothDamp(HealthBar.localScale, new Vector3(size, size, size), ref Velocity, 20 * Time.deltaTime);
    }

    private void UpdateCharge()
    {
        float size = Charge / MaxCharge;
        if (size < 0)
        {
            size = 0;
        }
        Arm_L.localScale = Vector3.SmoothDamp(Arm_L.localScale, new Vector3(size, size, size), ref Velocity_2, 20 * Time.deltaTime);
        Arm_R.localScale = Vector3.SmoothDamp(Arm_R.localScale, new Vector3(size, size, size), ref Velocity_3, 20 * Time.deltaTime);
    }

    public void Move()
    {
        var step = 30 * Time.deltaTime;
        if (isLeft)
        {
            Boss.RotateAround(new Vector3(0, 0, 0), Vector3.up, step);
        }
        else
        {
            Boss.RotateAround(new Vector3(0, 0, 0), Vector3.up, -(step));
        }
    }

    public void AddCharge()
    {
        Charge = Charge + 1;
        if (Charge == MaxCharge)
        {
            canMove = false;
            StopAllCoroutines();
            StartCoroutine(StartBeamAttack());
        }
    }

    public void ResetCharge()
    {
        Charge = 0;
    }

    public void SpawnCharger()
    {
        int rng = 0;
        bool done = false;

        while (!done)
        {
            rng = Random.Range(0, 4);

            switch (rng)
            {
                case 0:
                    if (!Charger.activeInHierarchy)
                    {
                        Charger.SetActive(true);
                        done = true;
                    }
                    break;
                case 1:
                    if (!Charger_1.activeInHierarchy)
                    {
                        Charger_1.SetActive(true);
                        done = true;
                    }
                    break;
                case 2:
                    if (!Charger_2.activeInHierarchy)
                    {
                        Charger_2.SetActive(true);
                        done = true;
                    }
                    break;
                case 3:
                    if (!Charger_3.activeInHierarchy)
                    {
                        Charger_3.SetActive(true);
                        done = true;
                    }
                    break;
            }
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(Enemy, SpawnPoint.position, Quaternion.identity);
    }

    IEnumerator StartBeamAttack()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("ShootBeam");
        yield return new WaitForSeconds(5);
        canMove = true;

        StartCoroutine(BossLoop());
        StartCoroutine(MoveDiraction());
    }

    IEnumerator BossLoop()
    {
        while (true)
        {
            count++;
            if (count <= 3)
            {
                yield return new WaitForSeconds(5);
                animator.SetTrigger("Shoot");
            }
            else
            {
                count = 0;
                if (!(Charger.activeInHierarchy && Charger.activeInHierarchy && Charger.activeInHierarchy && Charger.activeInHierarchy))
                {
                    yield return new WaitForSeconds(2);
                    animator.SetTrigger("SpawnCharger");
                    canMove = false;
                    yield return new WaitForSeconds(2);
                    canMove = true;
                }
            }            
        }
    }

    IEnumerator MoveDiraction()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 10));

            isLeft = !isLeft;
        }
    }
}
