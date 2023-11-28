using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixerMusic;
    public AudioMixer audioMixerSound;

    [SerializeField] Slider SliderMusic;
    [SerializeField] Slider SliderSound;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetFloat("Music", 0f);
            PlayerPrefs.SetFloat("Sound", 0f);
        }
        float Music = PlayerPrefs.GetFloat("Music");
        float Sound = PlayerPrefs.GetFloat("Sound");

        SliderMusic.value = Music;
        SliderSound.value = Sound;

        audioMixerMusic.SetFloat("MasterVolume", Music);
        audioMixerSound.SetFloat("MasterVolume", Sound);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixerMusic.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("Music", volume);
    }

    public void SetSoundVolume(float volume)
    {
        audioMixerSound.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("Sound", volume);
    }
}
