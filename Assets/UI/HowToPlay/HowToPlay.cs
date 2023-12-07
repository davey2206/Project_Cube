using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] List<GameObject> tutorials;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject Tutorial;

    int counter = 0;
    GameObject cube;
    private void OnEnable()
    {
        cube = GameObject.Find("MainCube");
        cube.SetActive(false);
    }

    public void Next()
    {
        menu.SetActive(true);
        cube.SetActive(true);
        Tutorial.SetActive(false);
    }
}
