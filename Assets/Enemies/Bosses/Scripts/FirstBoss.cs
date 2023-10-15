using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameObject ArmL;
    [SerializeField] GameObject ArmR;
    [SerializeField] Animator animator;
    [SerializeField] List<Animation> animations;

    [Header("Attacks")]
    [SerializeField] List<Transform> spawnersFase1;
    [SerializeField] List<Transform> spawnersFase2;
    [SerializeField] List<Transform> spawnersFase3;
    [SerializeField] GameObject BossEnemy;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        animator.Play(animations[0].name);
    }

    public void Attack1()
    {
        Instantiate(BossEnemy, new Vector3(spawnersFase1[0].transform.position.x, spawnersFase1[0].transform.position.y, spawnersFase1[0].transform.position.z), Quaternion.Euler(20, 0, 20));
        Instantiate(BossEnemy, new Vector3(spawnersFase1[1].transform.position.x, spawnersFase1[1].transform.position.y, spawnersFase1[1].transform.position.z), Quaternion.Euler(20, 0, 20));
    }

    public void Attack2()
    {
        Instantiate(BossEnemy, new Vector3(spawnersFase2[0].transform.position.x, spawnersFase2[0].transform.position.y, spawnersFase2[0].transform.position.z), Quaternion.Euler(20, 0, 20));
        Instantiate(BossEnemy, new Vector3(spawnersFase2[1].transform.position.x, spawnersFase2[1].transform.position.y, spawnersFase2[1].transform.position.z), Quaternion.Euler(20, 0, 20));
    }

    public void Attack3()
    {

    }
}
