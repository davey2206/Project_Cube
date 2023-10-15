using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float Speed;
    float attack;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(attack);
            Destroy(gameObject);
        }

        if (other.transform.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<DamageBoss>().TakeDamage(attack);
            Destroy(gameObject);
        }
    }

    public void SetAttack(float atk)
    {
        attack = atk;
    }
}
