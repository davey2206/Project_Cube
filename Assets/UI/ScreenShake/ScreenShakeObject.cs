using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Screen Shake", menuName = "ScriptableObjects/ScreenShake")]
public class ScreenShakeObject : ScriptableObject
{
    public float Amplitude;
    public float Frequency;
    public float SpeedOfDecay;
}
