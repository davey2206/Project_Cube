using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    [SerializeField] AudioSource audioSource1;
    [SerializeField] AudioSource audioSource2;
    [SerializeField] List<AudioClip> audioClips;

    public void HoverSoundEffect()
    {
        audioSource1.PlayOneShot(audioClips[0], 0.1f);
    }

    public void ClickSoundEffect()
    {
        audioSource2.PlayOneShot(audioClips[1], 0.5f);
    }
}
