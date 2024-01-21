using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPitch : MonoBehaviour
{
    [Range(-3,2.9f)]
    [SerializeField] float MinPitch;
    [Range(-2.9f, 3)]
    [SerializeField] float MaxPitch;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().pitch= Random.Range(MinPitch, MaxPitch);
    }
}
