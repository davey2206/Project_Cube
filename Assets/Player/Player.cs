using SimpleAudioManager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    [SerializeField] ScreenShakeObject screenShake;

    Manager audioManager;
    Vector3 Velocity;

    private void Awake()
    {
        ResetPlayer();
        audioManager = GameObject.Find("SimpleAudioManager").GetComponent<Manager>();
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
        ActivateAbilitiesOnHit();
        if (playerStats.Shields == 0)
        {
            Health--;
        }
        else
        {
            playerStats.Shields--;
        }

        if (Health <= 0)
        {
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

    public bool canHeal()
    {
        if (Health == playerStats.maxHealth)
        {
            return false;
        }

        return true;
    }

    IEnumerator EndGame()
    {
        playerStats.alive = false;
        playerStats.AddCoins();
        GameObject.Find("SaveSystem").GetComponent<SaveSystem>().SaveGame();
        Instantiate(PlayerDieEffect, new Vector3(0, 5, 0), Quaternion.identity);
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Animator>().SetTrigger("Die");

        yield return new WaitForEndOfFrame();
        screenShake.Amplitude = 0.5f;
        screenShake.SpeedOfDecay = 0f;
        yield return new WaitForSeconds(2.1f);
        screenShake.Amplitude = 5.0f;
        screenShake.SpeedOfDecay = 0.5f;


        yield return new WaitForSeconds(1.4f);

        audioManager.PlaySong(3);
        gameEnd.SetActive(true);
        gameStartText.text = "Game Over";
        Time.timeScale = 0f;
    }
}
