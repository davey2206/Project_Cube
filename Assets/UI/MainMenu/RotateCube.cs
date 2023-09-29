using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles += new Vector3(0,10,0) * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, 0, 1) * Time.deltaTime;
    }
}
