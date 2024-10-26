using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject Switch_1;
    [SerializeField] GameObject Switch_2;
    [SerializeField] GameObject Skins_1;
    [SerializeField] GameObject Skins_2;

    public void SwitchSkins()
    {
        Switch_1.SetActive(!Switch_1.activeInHierarchy);
        Switch_2.SetActive(!Switch_2.activeInHierarchy);
        Skins_1.SetActive(!Skins_1.activeInHierarchy);
        Skins_2.SetActive(!Skins_2.activeInHierarchy);
    }
}
