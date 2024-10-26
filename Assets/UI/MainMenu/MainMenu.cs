using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject Menu;
    [SerializeField] AudioManeger audioManeger;

    MainCubeAnimations cubeAnimator;
    sceneManager sceneManager;

    private void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<sceneManager>();
        cubeAnimator = GameObject.Find("MainCube").GetComponent<MainCubeAnimations>();
    }

    public void Play()
    {
        animator.SetTrigger("Play");
        sceneManager.MainSceneLoad();
        audioManeger.AudioSources = 0;
    }

    public void Upgrade()
    {
        animator.SetTrigger("Upgrade");
        cubeAnimator.Upgrades();
    }

    public void Exit()
    {
        PlayerPrefs.SetInt("Warning", 0);
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

    public void ToSkin()
    {
        animator.SetTrigger("ToSkin");
        cubeAnimator.ToSkin();
    }

    public void SkinToMenu()
    {
        animator.SetTrigger("SkinToMenu");
        cubeAnimator.SkinToMenu();
    }
}
