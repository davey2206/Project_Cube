using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVFX : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] abilitiesObject abilities;
    [SerializeField] ColorEnum color;
    [SerializeField] WaveVFX wave;

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
        transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(0.5f, 0.5f, 0.5f), ref Velocity, 10 * Time.deltaTime);
    }

    public void UpdateColor(ColorEnum colorEnum)
    {
        switch (colorEnum)
        {
            case ColorEnum.White:
                wave.SetColor(new Color(1,1,1,0));
                break;
            case ColorEnum.Blue:
                wave.SetColor(new Color(0, 1, 1, 0));
                break;
            case ColorEnum.Green:
                wave.SetColor(new Color(0.169284f, 1f, 0f, 0));
                break;
            case ColorEnum.Yellow:
                wave.SetColor(new Color(1, 1, 0, 0));
                break;
        }

        color = colorEnum;
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
            enemy.TakeDamage(playerStats.GetAttack(), color);

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
            enemy.TakeDamage(playerStats.GetAttack(), color);

            if (!FirstEnemyHit)
            {
                Vector3 pos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, 0, cam.ScreenToWorldPoint(Input.mousePosition).z);
                ActivateAbilitiesOnClick(pos);
                FirstEnemyHit = true;
            }
        }

        if (other.transform.CompareTag("ArmSpawnerHealth"))
        {
            ArmSpawnerHealth enemy = other.transform.GetComponent<ArmSpawnerHealth>();
            enemy.TakeDamage(playerStats.GetAttack(), color);

            if (!FirstEnemyHit)
            {
                Vector3 pos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, 0, cam.ScreenToWorldPoint(Input.mousePosition).z);
                ActivateAbilitiesOnClick(pos);
                FirstEnemyHit = true;
            }
        }
    }
}
