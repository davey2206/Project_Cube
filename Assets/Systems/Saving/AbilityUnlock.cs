using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AbilityUnlock
{
    public bool unlocked;

    public AbilityUnlock(bool unlock)
    {
        unlocked = unlock;
    }
}
