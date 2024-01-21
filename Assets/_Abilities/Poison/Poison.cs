using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    [SerializeField] Collider hitBox;
    float AttackSpeed;

    public void SetAttackSpeed(float a)
    {
        AttackSpeed = a;
    }

    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(AttackSpeed);
            hitBox.enabled = false;
            yield return new WaitForFixedUpdate();
            hitBox.enabled = true;
        }
    }
}
