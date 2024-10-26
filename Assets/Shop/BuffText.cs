using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuffText : MonoBehaviour
{
    [SerializeField] PlayerStats Stats;
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] StatType Type;

    float stat;

    // Update is called once per frame
    void Update()
    {
        stat = 0;

        foreach (var buff in Stats.Buffs)
        {
            stat += buff.GainStat(Type);
        }

        Text.text = stat.ToString();
    }
}
