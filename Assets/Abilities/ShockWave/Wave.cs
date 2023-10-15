using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Wave : MonoBehaviour
{
    float attack;
    float stunTime;

    private void Start()
    {
        Destroy(gameObject, 1f);
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
}
