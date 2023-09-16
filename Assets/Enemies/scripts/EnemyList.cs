using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyList
{
    public GameObject Enemy;
    public int NumberOfSpawns;
    [Range(0,60)]
    public float TimeOfSpawn;
}
