using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbedWireWave : MonoBehaviour
{
    Vector3 Velocity;
    float attack;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }
    public void SetStats(float atk)
    {
        attack = atk;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.SmoothDamp(transform.localScale, new Vector3(5,5,5), ref Velocity, 20 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(attack);
        }
    }
}
