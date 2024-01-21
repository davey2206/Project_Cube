using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallScreenShake : MonoBehaviour
{
    [SerializeField] ScreenShakeObject screenShake;
    void Start()
    {
        screenShake.Amplitude = 0.5f;
        screenShake.SpeedOfDecay = 0.25f;
    }
}
