using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class Player : MonoBehaviour
{
    [SerializeField] float Health;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Transform HealthBar;
    [SerializeField] GameObject PlayerDieEffect;
    [SerializeField] abilitiesObject abilities;

    
    Vector3 Velocity;
    private void Start()
    {
        Health = playerStats.maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            Health--;
            ActivateAbilitiesOnHit();
            if (Health <= 0)
            {
                Instantiate(PlayerDieEffect, new Vector3(0,5,0), Quaternion.identity);
                GetComponent<BoxCollider>().enabled= false;
                GetComponent<Animator>().SetTrigger("Die");
            }
            other.gameObject.GetComponent<Enemy>().HitPlayer();
        }
    }


    private void Update()
    {
        float size = Health / playerStats.maxHealth;
        HealthBar.localScale = Vector3.SmoothDamp(HealthBar.localScale, new Vector3(size, size, size), ref Velocity, 20 * Time.deltaTime);
    }

    public void ActivateAbilitiesOnHit()
    {
        foreach (var abilitie in abilities.abilities)
        {
            if (abilitie.abilityType == AbilityTypes.PlayerHit && abilitie.Active == true)
            {
                abilitie.Ability.Invoke(abilitie.Level, transform.position);
            }
        }
    }
}
