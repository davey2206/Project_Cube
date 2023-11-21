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
        if (counter != 2)
        {
            tutorials[counter].SetActive(false);
            counter++;
            tutorials[counter].SetActive(true);
        }
        else
        {
            counter = 0;
            tutorials[0].SetActive(true);
            tutorials[1].SetActive(false);
            tutorials[2].SetActive(false);
            menu.SetActive(true);
            cube.SetActive(true);
            Tutorial.SetActive(false);
        }
    }
}
