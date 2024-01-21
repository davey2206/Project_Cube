using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class AttackVFX : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] abilitiesObject abilities;

    Camera cam;
    bool FirstEnemyHit;
    private void Start()
    {
        cam = Camera.main;
        FirstEnemyHit = false;
    }

    Vector3 Velocity;
    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(0.5f, 0.5f, 0.5f), ref Velocity, 50 * Time.deltaTime);
    }

    public void ActivateAbilitiesOnClick(Vector3 pos)
    {
        foreach (var abilitie in abilities.abilities)
        {
            if (abilitie.abilityType == AbilityTypes.Click && abilitie.Active == true)
            {
                abilitie.Ability.Invoke(abilitie.Level, pos);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            Enemy enemy = other.transform.GetComponent<Enemy>();
            enemy.TakeDamage(playerStats.GetAttack());

            if (!FirstEnemyHit)
            {
                Vector3 pos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, 0, cam.ScreenToWorldPoint(Input.mousePosition).z);
                ActivateAbilitiesOnClick(pos);
                FirstEnemyHit = true;
            }
        }

        if (other.transform.CompareTag("Boss"))
        {
            DamageBoss enemy = other.transform.GetComponent<DamageBoss>();
            enemy.TakeDamage(playerStats.GetAttack());

            if (!FirstEnemyHit)
            {
                Vector3 pos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, 0, cam.ScreenToWorldPoint(Input.mousePosition).z);
                ActivateAbilitiesOnClick(pos);
                FirstEnemyHit = true;
            }
        }
    }
}
