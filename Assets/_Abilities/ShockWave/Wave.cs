using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.VFX;

public class Wave : MonoBehaviour
{
    float attack;
    float stunTime;
    [SerializeField] ScreenShakeObject screenShake;
    [SerializeField] ColorEnum color;

    private void Start()
    {
        Destroy(gameObject, 1f);
        StartCoroutine(shake());
    }

    public void SetStats(float stun, float atk)
    {
        stunTime = stun;
        attack = atk;
    }
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * 2, Time.deltaTime * 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            Enemy enemy = other.transform.GetComponent<Enemy>();
            enemy.TakeDamage(attack, color);
            enemy.Stun(stunTime);
        }

        if (other.transform.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<DamageBoss>().TakeDamage(attack, color);
        }

        if (other.transform.CompareTag("ArmSpawnerHealth"))
        {
            ArmSpawnerHealth enemy = other.transform.GetComponent<ArmSpawnerHealth>();
            enemy.TakeDamage(attack, color);
        }
    }

    IEnumerator shake()
    {
        yield return new WaitForSeconds(0.75f);
        screenShake.Amplitude = 1f;
        screenShake.SpeedOfDecay = 0.25f;
    }
}
