using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundEffect : MonoBehaviour
{
    [SerializeField] List<AudioClip> audioClips;

    void Start()
    {
        GetComponent<AudioSource>().clip = audioClips[Random.Range(0, audioClips.Count)];
        GetComponent<AudioSource>().Play();
    }
}
