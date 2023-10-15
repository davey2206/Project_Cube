using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    sceneManager sceneManager;
    public void MainMenu()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<sceneManager>();
        sceneManager.MenuSceneLoad();
    }
}
