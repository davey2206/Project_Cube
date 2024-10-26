using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPlayer : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }


    void Update()
    {
        Vector3 rotation = Quaternion.LookRotation(transform.position - player.position).eulerAngles;
        rotation.x = 30f;
        rotation.z = 0f;

        transform.rotation = Quaternion.Euler(rotation);
    }
}
