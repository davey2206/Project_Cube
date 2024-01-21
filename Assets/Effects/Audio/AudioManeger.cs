using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioManeger", menuName = "ScriptableObjects/AudioManeger")]
public class AudioManeger : ScriptableObject
{
    public int AudioSources;

    public bool CanSpawnAudio()
    {
        if (AudioSources <= 40)
        {
            return true;
        }

        return false;
    }
}
