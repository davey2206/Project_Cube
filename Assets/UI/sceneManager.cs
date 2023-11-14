using SimpleAudioManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    string MainScene;
    string MenuScene;

    Manager audioManager;
    MainCubeAnimations cubeAnimator;

    Scene menuScene;
    Scene mainScene;

    private void Awake()
    {
        MainScene = SceneUtility.GetScenePathByBuildIndex(3);
        MenuScene = SceneUtility.GetScenePathByBuildIndex(2);
    }

    private IEnumerator Start()
    {
        PlayMusic(0);
        SceneManager.LoadSceneAsync(MenuScene, LoadSceneMode.Additive);
        menuScene = SceneManager.GetSceneByPath(MenuScene);

        while (!menuScene.isLoaded)
        {
            yield return new WaitForEndOfFrame();
        }

        SceneManager.SetActiveScene(menuScene);
    }

    public void MainSceneLoad()
    {
        StartCoroutine(MainSceneTimer());
    }

    public void MenuSceneLoad()
    {
        Time.timeScale = 1f;
        StartCoroutine(MenuSceneTimer());
    }

    public IEnumerator MenuSceneTimer()
    {
        Time.timeScale = 1f;
        GameObject.Find("EventSystem").SetActive(false);
        GameObject light = GameObject.Find("Directional Light");

        MenuScene = SceneUtility.GetScenePathByBuildIndex(2);
        SceneManager.LoadSceneAsync(MenuScene, LoadSceneMode.Additive);

        PlayMusic(0);

        menuScene = SceneManager.GetSceneByPath(MenuScene);

        while (!menuScene.isLoaded)
        {
            yield return new WaitForEndOfFrame();
        }
        light.SetActive(false);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.SetActiveScene(menuScene);
    }

    IEnumerator MainSceneTimer()
    {
        GameObject.Find("EventSystem").SetActive(false);
        GameObject light = GameObject.Find("Directional Light");

        MainScene = SceneUtility.GetScenePathByBuildIndex(3);
        SceneManager.LoadSceneAsync(MainScene, LoadSceneMode.Additive);

        mainScene = SceneManager.GetSceneByPath(MainScene);

        while (!mainScene.isLoaded)
        {
            yield return new WaitForEndOfFrame();
        }
        light.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        PlayMusic(1);

        cubeAnimator = GameObject.Find("MainCube").GetComponent<MainCubeAnimations>();
        cubeAnimator.Main();

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.SetActiveScene(mainScene);
    }

    public void PlayMusic(int index)
    {
        audioManager = GameObject.Find("SimpleAudioManager").GetComponent<Manager>();
        audioManager.PlaySong(index);
    }
}
