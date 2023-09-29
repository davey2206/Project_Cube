using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetUpgrade : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI Unlocks;
    [SerializeField] TextMeshProUGUI Price;

    [SerializeField] Upgrade upgrade;

    private void Update()
    {
        Name.text = upgrade.Name;
        Unlocks.text = upgrade.getUnlock();
        Price.text = upgrade.getCost();
    }
}
