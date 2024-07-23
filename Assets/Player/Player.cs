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
    [SerializeField] abilitiesObject abilities;

    [Header("Effects")]
    [SerializeField] GameObject PlayerDieEffect;
    [SerializeField] GameObject PlayerDieEffect2;
    [SerializeField] GameObject PlayerDieEffect3;
    [SerializeField] GameObject PlayerDieEffect4;
    [SerializeField] HitEffect hitEffect;
    [SerializeField] ScreenShakeObject screenShake;

    [Header("UI")]
    [SerializeField] GameObject gameEnd;
    [SerializeField] TextMeshProUGUI gameStartText;

    public ColorEnum color;

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
            hitEffect.Hit();
            screenShake.Amplitude = 0.5f;
            screenShake.SpeedOfDecay = 0.25f;
        }

        if (other.transform.CompareTag("BossHitBox"))
        {
            TakeBossDamage();
            hitEffect.Hit();
            screenShake.Amplitude = 0.5f;
            screenShake.SpeedOfDecay = 0.25f;
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

    public void TakeBossDamage()
    {
        ActivateAbilitiesOnHit();
        if (playerStats.Shields == 0)
        {
            Health -= 0.5f;
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
        switch (color)
        {
            case ColorEnum.White:
                Instantiate(PlayerDieEffect, new Vector3(0, 5, 0), Quaternion.identity);
                break;
            case ColorEnum.Blue:
                Instantiate(PlayerDieEffect2, new Vector3(0, 5, 0), Quaternion.identity);
                break;
            case ColorEnum.Green:
                Instantiate(PlayerDieEffect3, new Vector3(0, 5, 0), Quaternion.identity);
                break;
            case ColorEnum.Yellow:
                Instantiate(PlayerDieEffect4, new Vector3(0, 5, 0), Quaternion.identity);
                break;
        }
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
