using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormChange : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Player player;
    [SerializeField] AttackVFX attackVFX;
    [SerializeField] Renderer mainMet;
    [SerializeField] Renderer subMet;

    [Header("Abilties")]
    [SerializeField] GameObject strike;
    [SerializeField] Wave ShockWave;
    [SerializeField] GameObject Mine;

    [Header("Sound Effects")]
    [SerializeField] GameObject YellowSFX;

    [Header("UI")]
    [SerializeField] Animator animator;
    [SerializeField] List<Image> images;
    [SerializeField] ScreenShakeObject screenShake;

    bool onCooldown;
    bool BonusAttack;
    bool BonusAttackSpeed;
    void Update()
    {
        ChangeForm();
    }

    private void Start()
    {
        attackVFX.UpdateColor(ColorEnum.White);
    }

    public void ChangeForm()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !onCooldown)
        {
            mainMet.material.color = Color.white;
            subMet.material.color = new Color(1f, 1f, 1f, 0.5f);
            White();
            StartCoroutine(ActiveCooldown());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !onCooldown)
        {
            mainMet.material.color = new Color(0.169284f, 1f, 0f, 1f);
            subMet.material.color = new Color(0.169284f, 1f, 0f, 0.5f);
            Green();
            StartCoroutine(ActiveCooldown());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && !onCooldown)
        {
            mainMet.material.color = new Color(1f, 1f, 0f, 1f);
            subMet.material.color = new Color(1f, 1f, 0f, 0.5f);
            Yellow();
            StartCoroutine(ActiveCooldown());
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && !onCooldown)
        {
            mainMet.material.color = new Color(0f, 1f, 1f, 1f);
            subMet.material.color = new Color(0f, 1f, 1f, 0.5f);
            Blue();
            StartCoroutine(ActiveCooldown());
        }
    }

    public void White()
    {
        player.color = ColorEnum.White;
        attackVFX.UpdateColor(ColorEnum.White);
        screenShake.Amplitude = 0.5f;
        screenShake.SpeedOfDecay = 0.25f;
        DisableAffect();

        Wave wave = Instantiate(ShockWave, Vector3.zero, Quaternion.identity);
        wave.SetStats(3, playerStats.GetAttack() * 0.5f);
    }

    public void Yellow()
    {
        player.color = ColorEnum.Yellow;
        attackVFX.UpdateColor(ColorEnum.Yellow);
        screenShake.Amplitude = 0.5f;
        screenShake.SpeedOfDecay = 0.25f;
        StartCoroutine(YellowShakeDelay(0.5f));
        DisableAffect();

        BonusAttack = true;
        playerStats.BonusAttack += 10;
        playerStats.AttackSpeed -= 1f;
        for (int i = 0; i < 4; i++)
        {
            GameObject attack = null;
            switch (i)
            {
                case 0:
                    attack = Instantiate(strike, new Vector3(0, 0, 5f), Quaternion.identity);
                    break;
                case 1:
                    attack = Instantiate(strike, new Vector3(9, 0, 0f), Quaternion.identity);
                    break;
                case 2:
                    attack = Instantiate(strike, new Vector3(-9, 0, 0f), Quaternion.identity);
                    break;
                case 3:
                    attack = Instantiate(strike, new Vector3(0, 0, -5f), Quaternion.identity);
                    break;
            }
            attack.GetComponentInChildren<WaveAttacks>(true).SetStats(0.01f, playerStats.GetAttack() * 1.5f);
        }
        
    }

    public void Green()
    {
        player.color = ColorEnum.Green;
        attackVFX.UpdateColor(ColorEnum.Green);
        screenShake.Amplitude = 0.5f;
        screenShake.SpeedOfDecay = 0.25f;
        DisableAffect();
        player.Heal(2f);

        for (int i = 0; i < 15; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-8f, 8f));

            var wave = Instantiate(Mine, pos, Quaternion.identity);
            wave.GetComponentInChildren<WaveAttacks>(true).SetStats(0.01f, playerStats.GetAttack() * 1.5f);
        }
    }

    public void Blue()
    {
        player.color = ColorEnum.Blue;
        attackVFX.UpdateColor(ColorEnum.Blue);
        screenShake.Amplitude = 0.5f;
        screenShake.SpeedOfDecay = 0.25f;
        DisableAffect();

        playerStats.AttackSpeed += 1f;
        playerStats.BonusAttack -= 10;

        BonusAttackSpeed = true;
        StartCoroutine(SuperAttackSpeed());
    }

    public void DisableAffect()
    {
        if (BonusAttack)
        {
            playerStats.BonusAttack -= 10;
            playerStats.AttackSpeed += 1f;

            BonusAttack = false;
        }

        if (BonusAttackSpeed)
        {
            playerStats.BonusAttack += 10;
            playerStats.AttackSpeed -= 1f;

            BonusAttackSpeed = false;
        }
    }

    IEnumerator SuperAttackSpeed()
    {
        playerStats.AttackSpeed += 10f;
        yield return new WaitForSeconds(5);
        playerStats.AttackSpeed -= 10f;
    }

    IEnumerator ActiveCooldown()
    {
        onCooldown = true;
        animator.SetTrigger("Used");
        foreach (var image in images)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
        }

        yield return new WaitForSeconds(playerStats.GetCooldown(18));

        foreach (var image in images)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        }
        animator.SetTrigger("Ready");
        onCooldown = false;
    }

    IEnumerator YellowShakeDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(YellowSFX, transform.position, Quaternion.identity);
        screenShake.Amplitude = 1f;
        screenShake.SpeedOfDecay = 0.25f;
    }
}
