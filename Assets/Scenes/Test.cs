using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float random;

    private void Start()
    {
        random = Random.Range(-0.1f,0.1f);
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.eulerAngles = gameObject.transform.eulerAngles + new Vector3(0, random, 0);
    }
}
