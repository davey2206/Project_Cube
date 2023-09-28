using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] PlayerStats playerStats;

    private void Update()
    {
        text.text = "Coins: " + playerStats.Coins;
    }
}
