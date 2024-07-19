using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : MonoBehaviour
{
    [Header("boss parts")]
    [SerializeField] DamageBoss Body;
    [SerializeField] DamageBoss ArmL;
    [SerializeField] DamageBoss ArmR;

    [SerializeField] Transform BodyCore;
    [SerializeField] Transform ArmLCore;
    [SerializeField] Transform ArmRCore;

    [Header("Stats")]
    [SerializeField] float Health;

    [Header("Effect / Animation")]
    [SerializeField] ScreenShakeObject ScreenShake;
    [SerializeField] Animator animator;
    [SerializeField] GameObject RawrSFX;
    [SerializeField] GameObject AttackSFX;
    [SerializeField] GameObject PrepereAttackSFX;
    [SerializeField] GameObject StunSFX;
    [SerializeField] GameObject StunRecoverSFX;
    [SerializeField] GameObject DeadVFX;

    [Header("Spawner")]
    [SerializeField] GameObject Enemy;
    [SerializeField] int Waves;
    [SerializeField] int SpawnAmount;

    bool charge = false;
    bool MoveToNextStart = false;
    bool Left = true;
    bool Scream = false;
    bool Stunned = false;

    private int ShieldCount;
    private float maxHealth;
    private Vector3 Velocity;
    private Vector3 dir;
    private Vector3 MovePoint;
    private Transform player;

    private IEnumerator Start()
    {
        maxHealth = Health;
        player = GameObject.Find("Player").transform;

        yield return new WaitForSeconds(2.5f);
        SetMovePoint();
    }

    void Update()
    {
        float size = Health / maxHealth;
        if (size < 0)
        {
            size = 0;
        }
        BodyCore.localScale = Vector3.SmoothDamp(BodyCore.localScale, new Vector3(size, size, size), ref Velocity, 20 * Time.deltaTime);
        ArmLCore.localScale = Vector3.SmoothDamp(ArmLCore.localScale, new Vector3(size, size, size), ref Velocity, 20 * Time.deltaTime);
        ArmRCore.localScale = Vector3.SmoothDamp(ArmRCore.localScale, new Vector3(size, size, size), ref Velocity, 20 * Time.deltaTime);

        if (charge)
        {
            transform.position += dir * Time.deltaTime * 4;
        }
        else if (MoveToNextStart && !Stunned)
        {
            Vector3 rotation = Quaternion.LookRotation(transform.position - player.position).eulerAngles;
            rotation.x = 0f;
            rotation.z = 0f;

            transform.rotation = Quaternion.Euler(rotation);

            var step = 15 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, MovePoint, step);

            if (transform.position == MovePoint && !Scream)
            {
                StartCoroutine(Charge());
            }
        }
    }

    public void Shield()
    {
        Body.SpawnShield();
        ArmL.SpawnShield();
        ArmR.SpawnShield();

        ShieldCount = 3;
    }

    public void CheckShield()
    {
        ShieldCount--;

        if (ShieldCount == 0)
        {
            Stunned = true;
            Scream = true;
            StopAllCoroutines();
            StartCoroutine(ScreamStart());
            Instantiate(StunSFX);
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Instantiate(DeadVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public IEnumerator Charge()
    {
        MoveToNextStart = false;
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("Charge");
        yield return new WaitForSeconds(0.5f);

        //Charge
        dir = player.position - transform.position;
        charge = true;
        Left = !Left;
        PlayAttackSound();

        yield return new WaitForSeconds(0.5f);
        charge = false;
        SetMovePoint();
    }

    private void SetMovePoint()
    {
        int z = 0;

        switch (Random.Range(0, 5))
        {
            case 0:
                z = -8;
                break;
            case 1:
                z = -4;
                break;
            case 2:
                z = 0;
                break;
            case 3:
                z = 4;
                break;
            case 4:
                z = 8;
                break;
        }

        if (Left)
        {
            MovePoint = new Vector3(-13, 0, z);
        }
        else
        {
            MovePoint = new Vector3(13, 0, z);
        }

        MoveToNextStart = true;
    }

    public IEnumerator ScreamStart()
    {
        animator.SetTrigger("Stun");
        charge= false;

        yield return new WaitForSeconds(5f);

        Stunned = false;

        yield return new WaitForSeconds(2f);

        animator.SetTrigger("ShieldUp");
        StartCoroutine(SpawnEnemies());

        yield return new WaitForSeconds(2.5f);
        MoveToNextStart = true;
        Scream = false;

        if (transform.position.x < 0)
        {
            Left = true;
        }
        else
        {
            Left = false;
        }
    }

    public IEnumerator SpawnEnemies()
    {
        Vector3 posRightTop = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
        Vector3 pos = new Vector3();
        int y = 0;
        int wave = 0;
        int SpawnPoints = SpawnAmount;

        while (wave != Waves)
        {
            while (SpawnPoints != 0)
            {
                SpawnPoints--;
                y++;
                switch (y)
                {
                    case 1:
                        pos = new Vector3(Random.Range(posRightTop.x, -posRightTop.x), 0, posRightTop.z + 1.5f);
                        break;
                    case 2:
                        pos = new Vector3(Random.Range(posRightTop.x, -posRightTop.x), 0, -posRightTop.z - 1.5f);
                        break;
                    case 3:
                        pos = new Vector3(posRightTop.x + 1.5f, 0, Random.Range(posRightTop.z, -posRightTop.z));
                        break;
                    case 4:
                        pos = new Vector3(-posRightTop.x - 1.5f, 0, Random.Range(posRightTop.x, -posRightTop.x));
                        break;
                }

                if (y == 4)
                {
                    y = 0;
                }

                Instantiate(Enemy, new Vector3(pos.x, 0, pos.z), Quaternion.Euler(20, 0, 20));
            }

            wave++;
            SpawnPoints = SpawnAmount;
            yield return new WaitForSeconds(5);
        }
    }

    public void PlayRawrSound()
    {
        Instantiate(RawrSFX);
        ScreenShake.Amplitude = 1f;
        ScreenShake.SpeedOfDecay = 0.25f;
    }

    public void PlayAttackSound()
    {
        Instantiate(AttackSFX);
        ScreenShake.Amplitude = 0.5f;
        ScreenShake.SpeedOfDecay = 0.25f;
    }

    public void PlayPrepereAttackSound()
    {
        Instantiate(PrepereAttackSFX);
    }
    public void PlayStunRecoverSound()
    {
        Instantiate(StunRecoverSFX);
    }
}
