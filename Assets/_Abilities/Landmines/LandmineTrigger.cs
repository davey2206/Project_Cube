using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineTrigger : MonoBehaviour
{
    [SerializeField] GameObject wave;
    [SerializeField] GameObject mine;
    [SerializeField] GameObject SFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy") || other.transform.CompareTag("Boss"))
        {
            Instantiate(SFX, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.5f);
            wave.SetActive(true);
            mine.SetActive(false);
        }

        if (other.transform.CompareTag("Player"))
        {
            Vector3 pos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
            transform.position = pos;
        }
    }
}
