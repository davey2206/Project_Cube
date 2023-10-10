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

    [SerializeField] Renderer mainMet;
    [SerializeField] Renderer subMet;

    Vector3 Velocity;
    bool onCooldown;
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

        ChangeForm();
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

    public void ChangeForm()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !onCooldown)
        {
            mainMet.material.color = Color.white;
            subMet.material.color = new Color(1f,1f,1f,0.5f);
            StartCoroutine(ActiveCooldown());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !onCooldown)
        {
            mainMet.material.color = new Color(0.169284f, 1f,0f,1f);
            subMet.material.color = new Color(0.169284f, 1f, 0f, 0.5f);
            StartCoroutine(ActiveCooldown());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && !onCooldown)
        {
            mainMet.material.color = new Color(1f, 1f, 0f, 1f);
            subMet.material.color = new Color(1f, 1f, 0f, 0.5f);
            StartCoroutine(ActiveCooldown());
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && !onCooldown)
        {
            mainMet.material.color = new Color(0f, 1f, 1f, 1f);
            subMet.material.color = new Color(0f, 1f, 1f, 0.5f);
            StartCoroutine(ActiveCooldown());
        }
    }

    IEnumerator ActiveCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(15);
        onCooldown = false;
    }
}
