using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeCubeMovement : MonoBehaviour
{
    [SerializeField] float Speed;

    Vector3 Target;

    void Update()
    {
        var step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target, step);
    }

    public void SetTarget(Vector3 target)
    {
        Target = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Charge"))
        {
            other.transform.parent.parent.GetComponent<ThirdBoss>().AddCharge();
        }
    }
}
