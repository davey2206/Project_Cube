using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> Texts;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Res") == 0 || PlayerPrefs.GetInt("Res") == null)
        {
            PlayerPrefs.SetInt("Res", 3);
        }

        SetScreenSize();
    }

    public void SetSize(int size)
    {
        PlayerPrefs.SetInt("Res", size);
        SetScreenSize();
    }

    public void SetScreenSize()
    {
        switch (PlayerPrefs.GetInt("Res"))
        {
            case 1:
                Texts[0].color = Color.white;
                Texts[1].color = Color.gray;
                Texts[2].color = Color.gray;
                Texts[3].color = Color.gray;
                Texts[4].color = Color.gray;
                Texts[5].color = Color.gray;

                Screen.SetResolution(640, 360, FullScreenMode.FullScreenWindow);
                break;
            case 2:
                Texts[0].color = Color.gray;
                Texts[1].color = Color.white;
                Texts[2].color = Color.gray;
                Texts[3].color = Color.gray;
                Texts[4].color = Color.gray;
                Texts[5].color = Color.gray;

                Screen.SetResolution(1280, 720, FullScreenMode.FullScreenWindow);
                break;
            case 3:
                Texts[0].color = Color.gray;
                Texts[1].color = Color.gray;
                Texts[2].color = Color.white;
                Texts[3].color = Color.gray;
                Texts[4].color = Color.gray;
                Texts[5].color = Color.gray;

                Screen.SetResolution(1600, 900, FullScreenMode.FullScreenWindow);
                break;
            case 4:
                Texts[0].color = Color.gray;
                Texts[1].color = Color.gray;
                Texts[2].color = Color.gray;
                Texts[3].color = Color.white;
                Texts[4].color = Color.gray;
                Texts[5].color = Color.gray;

                Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
                break;
            case 5:
                Texts[0].color = Color.gray;
                Texts[1].color = Color.gray;
                Texts[2].color = Color.gray;
                Texts[3].color = Color.gray;
                Texts[4].color = Color.white;
                Texts[5].color = Color.gray;

                Screen.SetResolution(2560, 1440, FullScreenMode.FullScreenWindow);
                break;
            case 6:
                Texts[0].color = Color.gray;
                Texts[1].color = Color.gray;
                Texts[2].color = Color.gray;
                Texts[3].color = Color.gray;
                Texts[4].color = Color.gray;
                Texts[5].color = Color.white;

                Screen.SetResolution(3840, 2160, FullScreenMode.FullScreenWindow);
                break;
        }
    }
}
