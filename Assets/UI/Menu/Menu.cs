using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pauze();
        }
    }

    public void Pauze()
    {
        foreach (var button in buttons)
        {
            button.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void BackToGame()
    {
        Time.timeScale = 1.0f;
        foreach (var button in buttons)
        {
            button.SetActive(false);
        }
    }
}
