using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public void Ability(int level, Vector3 pos)
    {
        GameObject.Find("Player").GetComponent<Player>().Heal(3);
    }
}
