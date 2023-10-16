using System.Collections;
using System.Collections.Generic;
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

    float WaitTime;

    private IEnumerator Start()
    {
        animator.Play(animations[3].name);
        yield return new WaitForSeconds(2f);
        animator.Play(animations[0].name);

        WaitTime = animations[0].length;
        while (true)
        {
            yield return new WaitForSeconds(WaitTime + 1f);

            if (ArmL.activeInHierarchy)
            {
                animator.Play(animations[0].name);
                WaitTime = animations[0].length;
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

    public void Attack1()
    {
        Instantiate(ShootEffect, ArmL.transform.position, Quaternion.identity);
        Instantiate(BossEnemy, new Vector3(spawnersFase1[0].transform.position.x, spawnersFase1[0].transform.position.y, spawnersFase1[0].transform.position.z), Quaternion.Euler(20, 0, 20));
        Instantiate(BossEnemy, new Vector3(spawnersFase1[1].transform.position.x, spawnersFase1[1].transform.position.y, spawnersFase1[1].transform.position.z), Quaternion.Euler(20, 0, 20));
    }

    public void Attack2()
    {
        Instantiate(ShootEffect, ArmR.transform.position, Quaternion.identity);
        Instantiate(BossEnemy, new Vector3(spawnersFase2[0].transform.position.x, spawnersFase2[0].transform.position.y, spawnersFase2[0].transform.position.z), Quaternion.Euler(20, 0, 20));
        Instantiate(BossEnemy, new Vector3(spawnersFase2[1].transform.position.x, spawnersFase2[1].transform.position.y, spawnersFase2[1].transform.position.z), Quaternion.Euler(20, 0, 20));
    }

    public void Attack3()
    {
        Instantiate(StumpEffect, transform.position, Quaternion.identity);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(BossEnemy, new Vector3(spawnersFase3[i].transform.position.x, spawnersFase3[i].transform.position.y, spawnersFase3[i].transform.position.z), Quaternion.Euler(20, 0, 20));
        }
    }

    private void Update()
    {
        if (!ArmL.activeInHierarchy && !ArmR.activeInHierarchy && !Body.activeInHierarchy)
        {
            Destroy(gameObject);
        }
    }
}
