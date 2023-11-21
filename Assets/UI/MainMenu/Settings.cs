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
            PlayerPrefs.SetFloat("Music", 2.25f);
            PlayerPrefs.SetFloat("Sound", 2.25f);
        }
        float Music = PlayerPrefs.GetFloat("Music");
        float Sound = PlayerPrefs.GetFloat("Sound");

        SliderMusic.value = Music;
        SliderSound.value = Sound;

        audioMixerMusic.SetFloat("MasterVolume", Mathf.Log10(Music) * 30);
        audioMixerSound.SetFloat("MasterVolume", Mathf.Log10(Sound) * 30);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixerMusic.SetFloat("MasterVolume", Mathf.Log10(volume) * 30);
        PlayerPrefs.SetFloat("Music", volume);
    }

    public void SetSoundVolume(float volume)
    {
        audioMixerSound.SetFloat("MasterVolume", Mathf.Log10(volume) * 30);
        PlayerPrefs.SetFloat("Sound", volume);
    }
}
