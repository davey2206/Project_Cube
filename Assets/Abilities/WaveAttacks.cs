using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAttacks : MonoBehaviour
{
    [SerializeField] float Size;

    Vector3 Velocity;
    float attack;
    float stun = 0;

    public void SetStats(float atk)
    {
        attack = atk;
    }

    public void SetStats(float s, float atk)
    {
        attack = atk;
        stun = s;
    }

    public void SetStats(float atk, float size, bool resize)
    {
        attack = atk;
        Size = size;
    }

    public void SetStats(float s, float atk, float size, bool resize)
    {
        attack = atk;
        stun = s;
        Size = size;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(Size, Size, Size), ref Velocity, 20 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(attack);
            other.gameObject.GetComponent<Enemy>().Stun(stun);
        }
    }
}
