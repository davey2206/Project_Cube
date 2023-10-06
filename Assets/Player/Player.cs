using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("UI")]
    [SerializeField] GameObject gameEnd;
    [SerializeField] TextMeshProUGUI gameStartText;

    Vector3 Velocity;
    private void Awake()
    {
        ResetPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("EnemyHitBox"))
        {
            TakeDamage();
            other.gameObject.transform.parent.GetComponent<Enemy>().HitPlayer();
        }
    }

    private void Update()
    {
        float size = Health / playerStats.maxHealth;
        HealthBar.localScale = Vector3.SmoothDamp(HealthBar.localScale, new Vector3(size, size, size), ref Velocity, 20 * Time.deltaTime);
    }

    public void TakeDamage()
    {
        Health--;
        ActivateAbilitiesOnHit();
        if (Health <= 0)
        {
            playerStats.alive = false;
            playerStats.AddCoins();
            Instantiate(PlayerDieEffect, new Vector3(0, 5, 0), Quaternion.identity);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Animator>().SetTrigger("Die");
            StartCoroutine(EndGame());
        }
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

    public void Heal(float heal)
    {
        Health = Health + heal;

        if (Health > playerStats.maxHealth)
        {
            Health = playerStats.maxHealth;
        }
    }

    public void ResetPlayer()
    {
        Health = playerStats.maxHealth;
        playerStats.ResetStats();
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3f);
        gameEnd.SetActive(true);
        gameStartText.text = "Game Over";
        Time.timeScale = 0f;
    }
}
