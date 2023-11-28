using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.HasKey("Warning"))
        {
            if (PlayerPrefs.GetInt("Warning") == 1)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void Close()
    {
        PlayerPrefs.SetInt("Warning", 1);
        gameObject.SetActive(false);
    }
}
