using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator;

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
}
