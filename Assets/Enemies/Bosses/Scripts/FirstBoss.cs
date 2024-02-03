using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class FirstBoss : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameObject ArmL;
    [SerializeField] GameObject ArmR;
    [SerializeField] GameObject Body;
    [SerializeField] Animator animator;
    [SerializeField] List<AnimationClip> animations;

    [Header("Attacks")]
    [SerializeField] List<Transform> spawnersFase1;
    [SerializeField] List<Transform> spawnersFase2;
    [SerializeField] List<Transform> spawnersFase3;
    [SerializeField] GameObject BossEnemy;

    [Header("VFX")]
    [SerializeField] GameObject StumpEffect;
    [SerializeField] GameObject ShootEffect;
    [SerializeField] ScreenShakeObject screenShake;

    [Header("SFX")]
    [SerializeField] GameObject AttackSFX;
    [SerializeField] GameObject PrepereSFX;
    [SerializeField] GameObject StumpSFX;
    [SerializeField] GameObject SpawnSFX;

    [Header("Cam")]
    [SerializeField] GameObject vCam;

    float WaitTime;
    bool Ready;

    private IEnumerator Start()
    {
        Ready = false;
        animator.Play(animations[3].name);
        yield return new WaitForEndOfFrame();
        ArmL.SetActive(true);
        ArmR.SetActive(true);
        Body.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        animator.Play(animations[0].name);
        Ready = true;
        WaitTime = animations[0].length;
        while (true)
        {
            yield return new WaitForSeconds(WaitTime + 1f);

            if (ArmL.activeInHierarchy)
            {
                int rng = Random.Range(0, 2);
                if (rng == 0)
                {
                    animator.Play(animations[0].name);
                    WaitTime = animations[0].length;
                }
                if (rng == 1)
                {
                    animator.Play(animations[4].name);
                    WaitTime = animations[4].length;
                }
            }

            if (!ArmL.activeInHierarchy && ArmR.activeInHierarchy)
            {
                animator.Play(animations[1].name);
                WaitTime = animations[1].length;
            }

            if (!ArmL.activeInHierarchy && !ArmR.activeInHierarchy)
            {
                animator.Play(animations[2].name);
                WaitTime = animations[2].length;
            }
        }
    }

    public void PrepereAttack()
    {
        Instantiate(PrepereSFX, transform.position, Quaternion.identity);
    }

    public void Spawn()
    {
        Instantiate(SpawnSFX, transform.position, Quaternion.identity);
        screenShake.Amplitude = 1.0f;
        screenShake.SpeedOfDecay = 0.1f;

        StartCoroutine(DisableVCam());
    }

    IEnumerator DisableVCam()
    {
        yield return new WaitForSeconds(1f);

        vCam.SetActive(false);
    }
    public void Attack1_2()
    {
        Instantiate(ShootEffect, ArmL.transform.position, Quaternion.identity);
        Instantiate(AttackSFX, ArmL.transform.position, Quaternion.identity);
        Instantiate(BossEnemy, new Vector3(spawnersFase1[2].transform.position.x, spawnersFase1[2].transform.position.y, spawnersFase1[2].transform.position.z), Quaternion.Euler(20, 0, 20));
        Instantiate(BossEnemy, new Vector3(spawnersFase1[3].transform.position.x, spawnersFase1[3].transform.position.y, spawnersFase1[3].transform.position.z), Quaternion.Euler(20, 0, 20));
        Instantiate(BossEnemy, new Vector3(spawnersFase1[4].transform.position.x, spawnersFase1[4].transform.position.y, spawnersFase1[4].transform.position.z), Quaternion.Euler(20, 0, 20));
        Instantiate(BossEnemy, new Vector3(spawnersFase1[5].transform.position.x, spawnersFase1[5].transform.position.y, spawnersFase1[5].transform.position.z), Quaternion.Euler(20, 0, 20));
    }

    public void Attack1()
    {
        Instantiate(ShootEffect, ArmL.transform.position, Quaternion.identity);
        Instantiate(AttackSFX, ArmL.transform.position, Quaternion.identity);
        Instantiate(BossEnemy, new Vector3(spawnersFase1[0].transform.position.x, spawnersFase1[0].transform.position.y, spawnersFase1[0].transform.position.z), Quaternion.Euler(20, 0, 20));
        Instantiate(BossEnemy, new Vector3(spawnersFase1[1].transform.position.x, spawnersFase1[1].transform.position.y, spawnersFase1[1].transform.position.z), Quaternion.Euler(20, 0, 20));
    }

    public void Attack2()
    {
        Instantiate(ShootEffect, ArmR.transform.position, Quaternion.identity);
        Instantiate(AttackSFX, ArmR.transform.position, Quaternion.identity);
        Instantiate(BossEnemy, new Vector3(spawnersFase2[0].transform.position.x, spawnersFase2[0].transform.position.y, spawnersFase2[0].transform.position.z), Quaternion.Euler(20, 0, 20));
        Instantiate(BossEnemy, new Vector3(spawnersFase2[1].transform.position.x, spawnersFase2[1].transform.position.y, spawnersFase2[1].transform.position.z), Quaternion.Euler(20, 0, 20));
    }

    public void Attack3()
    {
        Instantiate(StumpEffect, transform.position, Quaternion.identity);
        Instantiate(StumpSFX, transform.position, Quaternion.identity);
        screenShake.Amplitude = 1.0f;
        screenShake.SpeedOfDecay = 0.25f;
        for (int i = 0; i < 20; i++)
        {
            Instantiate(BossEnemy, new Vector3(spawnersFase3[i].transform.position.x, spawnersFase3[i].transform.position.y, spawnersFase3[i].transform.position.z), Quaternion.Euler(20, 0, 20));
        }
    }

    private void Update()
    {
        if (!ArmL.activeInHierarchy && !ArmR.activeInHierarchy && !Body.activeInHierarchy && Ready)
        {
            Destroy(gameObject);
        }
    }
}
