using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveClickWave : MonoBehaviour
{
    Vector3 Velocity;
    float Size;
    float attack;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }
    public void SetStats(float atk, float size)
    {
        attack = atk;
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
        }
    }
}
