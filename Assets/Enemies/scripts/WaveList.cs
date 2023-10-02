using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaveList
{
    public int difficulty;
    public int spawnPoints;
    [Range(0, 15)]
    public float waveLength;
}
