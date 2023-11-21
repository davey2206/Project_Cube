using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject HowToPlay;

    MainCubeAnimations cubeAnimator;
    sceneManager sceneManager;
    private void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<sceneManager>();
        cubeAnimator = GameObject.Find("MainCube").GetComponent<MainCubeAnimations>();
    }

    public void Play()
    {
        sceneManager.MainSceneLoad();
    }

    public void Upgrade()
    {
        animator.SetTrigger("Upgrade");
        cubeAnimator.Upgrades();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        animator.SetTrigger("MainMenu");
        cubeAnimator.Menu();
    }

    public void Settings()
    {
        animator.SetTrigger("Settings");
    }

    public void BackToMenu()
    {
        animator.SetTrigger("SettingsToMenu");
    }

    public void Tutorial()
    {
        HowToPlay.SetActive(true);
        Menu.SetActive(false);
    }
}
