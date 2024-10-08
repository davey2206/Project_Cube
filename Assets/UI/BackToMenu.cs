using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    sceneManager sceneManager;
    public void MainMenu()
    {
        Time.timeScale = 1f;
        sceneManager = GameObject.Find("SceneManager").GetComponent<sceneManager>();
        GameObject.Find("MainCube").GetComponent<MainCubeAnimations>().BackMenu();
        sceneManager.MenuSceneLoad();
    }
}
