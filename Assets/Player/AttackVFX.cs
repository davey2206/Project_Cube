using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVFX : MonoBehaviour
{
    Vector3 Velocity;
    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(0.3f, 0.3f, 0.3f), ref Velocity, 20 * Time.deltaTime);
    }
}
