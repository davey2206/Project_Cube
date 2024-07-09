using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] SaveFile saveFile;
    [SerializeField] bool IsSaveFile;

    // Update is called once per frame
    void Update()
    {
        if (IsSaveFile)
        {
            text.text = "Coins: " + saveFile.coins.ToString();
        }
        else
        {
            text.text = "Coins: " + playerStats.Coins.ToString();
        }
    }
}
