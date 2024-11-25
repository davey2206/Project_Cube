using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SecondBoss : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] SecondBossHealth Health;
    [SerializeField] Transform Core;
    [SerializeField] GameObject DeadVFX;

    [Header("Animations")]
    [SerializeField] Animator Ani;

    [Header("Stats")]
    [SerializeField] float Speed;

    [Header("Boss")]
    [SerializeField] Transform ArmL;
    [SerializeField] Transform ArmR;
    [SerializeField] Transform Boss;

    [Header("Spawners")]
    [SerializeField] GameObject ArmSpawner;

    private bool isLeft;
    private bool canMove;
    private bool canSpawn = false;
    private bool rotate = false;
    private bool dead = false;
    private Vector3 moveLocation = new Vector3(0, 0, 7);
    private Vector3 Velocity;

    private IEnumerator Start()
    {
        Health.ResetHealth();
        canMove = false;

        yield return new WaitForSeconds(1);

        canMove = true;
        StartCoroutine(GetMovePosition(1));
    }

    private void Update()
    {
        if (canMove && !dead)
        {
            var step = Speed * Time.deltaTime;
            if (moveLocation == new Vector3(0, 0, 7) && !canSpawn)
            {
                if (Vector3.Distance(Boss.position, moveLocation) > 0.1f && !rotate)
                {
                    Boss.position = Vector3.MoveTowards(Boss.position, moveLocation, step);
                }
                else
                {
                    if (isLeft)
                    {
                        Boss.RotateAround(new Vector3(0, 0, 0), Vector3.up, step * 3);
                    }
                    else
                    {
                        Boss.RotateAround(new Vector3(0, 0, 0), Vector3.up, -(step * 3));
                    }
                }

                if (Vector3.Distance(Boss.position, moveLocation) <= 0.1f)
                {
                    rotate = true;
                }
            }
            else if(canSpawn)
            {
                rotate = false;
                Boss.position = Vector3.MoveTowards(Boss.position, moveLocation, step);
            }

            if (Vector3.Distance(Boss.position, moveLocation) < 0.1f && canSpawn && !dead)
            {
                canSpawn = false;
                StartSpawnArm();
            }
        }

        float size = Health.GetHealth() / Health.GetMaxHealth();
        if (size < 0)
        {
            size = 0;
        }
        Core.localScale = Vector3.SmoothDamp(Core.localScale, new Vector3(size, size, size), ref Velocity, 20 * Time.deltaTime);

        if (Health.GetHealth() <= 0 && dead == false)
        {
            dead = true;
        }
    }

    public void SpawnArmL()
    {
        Instantiate(ArmSpawner, ArmL.position, Quaternion.identity);
        moveLocation = new Vector3(0, 0, 7);
        StartCoroutine(GetMovePosition(10));
    }

    public void SpawnArmR() 
    {
        Instantiate(ArmSpawner, ArmR.position, Quaternion.identity);
        moveLocation = new Vector3(0, 0, 7);
        StartCoroutine(GetMovePosition(10));
    }

    private void StartSpawnArm()
    {
        if (isLeft)
        {
            if (!ArmR.gameObject.activeInHierarchy)
            {
                Ani.SetTrigger("ArmLWithoutR");
            }
            else
            {
                Ani.SetTrigger("ArmL");
            }
        }
        else
        {
            if (!ArmL.gameObject.activeInHierarchy)
            {
                Ani.SetTrigger("ArmRWithoutL");
            }
            else
            {
                Ani.SetTrigger("ArmR");
            }
        }
    }

    private IEnumerator GetMovePosition(float time)
    {
        yield return new WaitForSeconds(time);

        Vector3 posRightTop = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));

        switch (Random.Range(1, 5))
        {
            case 1:
                moveLocation = new Vector3(Random.Range(posRightTop.x - 2, -posRightTop.x + 2), 0, -6);
                break;
            case 2:
                moveLocation = new Vector3(Random.Range(posRightTop.x - 2, -posRightTop.x + 2), 0, 6);
                break;
            case 3:
                moveLocation = new Vector3(-13, 0, Random.Range(posRightTop.z - 2, -posRightTop.z + 2));
                break;
            case 4:
                moveLocation = new Vector3(13, 0, Random.Range(posRightTop.z - 2, -posRightTop.z + 2));
                break;
        }

        if (!isLeft)
        {
            isLeft = true;
            if (!ArmL.gameObject.activeInHierarchy)
            {
                if (!ArmR.gameObject.activeInHierarchy)
                {
                    Ani.SetTrigger("ActiveLWithoutR");
                }
                else
                {
                    Ani.SetTrigger("ActiveL");
                }
            }
        }
        else
        {
            isLeft = false;
            if (!ArmR.gameObject.activeInHierarchy)
            {
                if (!ArmL.gameObject.activeInHierarchy)
                {
                    Ani.SetTrigger("ActiveRWithoutL");
                }
                else
                {
                    Ani.SetTrigger("ActiveR");
                }
            }
        }

        canSpawn = true;
    }

    private void Die()
    {
        Instantiate(DeadVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
