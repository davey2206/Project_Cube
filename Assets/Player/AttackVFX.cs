using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class AttackVFX : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] abilitiesObject abilities;

    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }

    Vector3 Velocity;
    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(0.5f, 0.5f, 0.5f), ref Velocity, 20 * Time.deltaTime);
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

            Vector3 pos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, 0, cam.ScreenToWorldPoint(Input.mousePosition).z);
            ActivateAbilitiesOnClick(pos);
        }
    }
}
