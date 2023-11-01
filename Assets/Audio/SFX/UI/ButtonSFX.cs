using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ButtonSFX : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] List<AudioClip> audioClips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void HoverSoundEffect()
    {
        audioSource.PlayOneShot(audioClips[0], 0.5f);
    }

    public void ClickSoundEffect()
    {
        audioSource.PlayOneShot(audioClips[1], 1f);
    }
}
