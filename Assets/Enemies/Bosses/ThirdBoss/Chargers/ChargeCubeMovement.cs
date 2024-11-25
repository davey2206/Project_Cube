using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeCubeMovement : MonoBehaviour
{
    [SerializeField] float Speed;

    Transform Target;

    void Update()
    {
        var step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Charge"))
        {
            other.transform.parent.GetComponent<ThirdBoss>().AddCharge();
            Destroy(gameObject);
        }
    }
}
