using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageNumbers : MonoBehaviour
{
    [SerializeField] float Damage;
    [SerializeField] TextMeshPro damageText;
    public void ShowDamage(float dmg)
    {
        Damage = dmg * 10;

        damageText.text = Damage.ToString("#.#");
    }

    public void Crit()
    {
        damageText.fontSize = damageText.fontSize + 5;
        damageText.color = new Color(1,0.4f,0,1);
    }
}
