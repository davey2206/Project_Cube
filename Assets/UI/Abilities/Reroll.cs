using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Reroll : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI text;

    private int Cost = 100;

    public void RerollCards()
    {
        playerStats.Coins -= Cost;

        Cost = Cost * 2;

        if (playerStats.Coins < Cost)
        {
            button.enabled = false;
        }

        text.text = Cost.ToString();
    }

    private void OnEnable()
    {
        Cost = 100;

        if (playerStats.Coins < Cost)
        {
            button.enabled = false;
        }
        else
        {
            button.enabled = true;
        }

        text.text = Cost.ToString();
    }
}
