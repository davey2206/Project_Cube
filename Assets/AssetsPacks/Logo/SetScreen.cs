using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetScreen : MonoBehaviour
{
    private void Awake()
    {
        if (Screen.height >= 2160)
        {
            Screen.SetResolution(3840, 2160, FullScreenMode.FullScreenWindow);
        }
        else if (Screen.height == 1440)
        {
            Screen.SetResolution(2560, 1440, FullScreenMode.FullScreenWindow);
        }
        else
        {
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        }
    }
}
