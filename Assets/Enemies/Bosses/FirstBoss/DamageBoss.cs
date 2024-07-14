using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageBoss : MonoBehaviour
{
    [SerializeField] Transform HealthBar;

    [Header("UI")]
    [SerializeField] DamageNumbers damageNumbers;

    [Header("Effects")]
    [SerializeField] GameObject HitSFX;
    [SerializeField] GameObject DieVFX;
    [SerializeField] GameObject ShieldWhiteBrakeVFX;
    [SerializeField] GameObject ShieldYellowBrakeVFX;
    [SerializeField] GameObject ShieldBlueBrakeVFX;
    [SerializeField] GameObject ShieldGreenBrakeVFX;

    [Header("Shield")]
    [SerializeField] GameObject ShieldWhite;
    [SerializeField] GameObject ShieldYellow;
    [SerializeField] GameObject ShieldBlue;
    [SerializeField] GameObject ShieldGreen;

    [Header("Evetns")]
    [SerializeField] UnityEvent ShieldBrakeEvent;
    [SerializeField] UnityEvent<float> DamageEvent;

    private ColorEnum ShieldColor;

    public void SpawnShield()
    {
        int rng = Random.Range(1, 5);

        switch (rng)
        {
            case 1:
                ShieldWhite.SetActive(true);
                ShieldColor = ColorEnum.White;
                break; 
            case 2:
                ShieldYellow.SetActive(true);
                ShieldColor = ColorEnum.Yellow;
                break;
            case 3:
                ShieldBlue.SetActive(true);
                ShieldColor = ColorEnum.Blue;
                break;
            case 4:
                ShieldGreen.SetActive(true);
                ShieldColor = ColorEnum.Green;
                break;
        }
    }

    public void TakeDamage(float damage, ColorEnum color)
    {
        if (ShieldWhite.activeInHierarchy)
        {
            if (color == ShieldColor)
            {
                ShieldWhite.SetActive(false);
                Instantiate(ShieldWhiteBrakeVFX, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
                ShieldBrakeEvent.Invoke();
            }
        }
        else if (ShieldYellow.activeInHierarchy)
        {
            if (color == ShieldColor)
            {
                ShieldYellow.SetActive(false);
                Instantiate(ShieldYellowBrakeVFX, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
                ShieldBrakeEvent.Invoke();
            }
        }
        else if (ShieldBlue.activeInHierarchy)
        {
            if (color == ShieldColor)
            {
                ShieldBlue.SetActive(false);
                Instantiate(ShieldBlueBrakeVFX, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
                ShieldBrakeEvent.Invoke();
            }
        }
        else if (ShieldGreen.activeInHierarchy)
        {
            if (color == ShieldColor)
            {
                ShieldGreen.SetActive(false);
                Instantiate(ShieldGreenBrakeVFX, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
                ShieldBrakeEvent.Invoke();
            }
        }
        else
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + Random.Range(-1f, 1f));

            DamageNumbers numbers = Instantiate(damageNumbers, pos, Quaternion.identity);
            numbers.ShowDamage(damage);

            DamageEvent.Invoke(damage);
        }
    }
}
