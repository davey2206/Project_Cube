using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoSpawn : MonoBehaviour
{
    [SerializeField] GameObject logo;
    public void SpawnLogo()
    {
        Instantiate(logo);
    }
}
