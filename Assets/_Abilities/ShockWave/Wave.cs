using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Wave : MonoBehaviour
{
    float attack;
    float stunTime;
    [SerializeField] ScreenShakeObject screenShake;

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
            other.gameObject.GetComponent<Enemy>().Stun(stunTime);
            other.gameObject.GetComponent<Enemy>().TakeDamage(attack);
        }

        if (other.transform.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<DamageBoss>().TakeDamage(attack);
        }
    }

    IEnumerator shake()
    {
        yield return new WaitForSeconds(0.75f);
        screenShake.Amplitude = 1f;
        screenShake.SpeedOfDecay = 0.25f;
    }
}
