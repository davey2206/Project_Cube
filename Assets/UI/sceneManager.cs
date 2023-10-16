using SimpleAudioManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    [SerializeField] GameObject cam;

    string MainScene;
    string MenuScene;

    Manager audioManager;
    MainCubeAnimations cubeAnimator;

    private void Awake()
    {
        MainScene = SceneUtility.GetScenePathByBuildIndex(3);
        MenuScene = SceneUtility.GetScenePathByBuildIndex(2);
    }

    private IEnumerator Start()
    {
        SceneManager.LoadSceneAsync(MenuScene, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync(MainScene, LoadSceneMode.Additive);

        yield return new WaitForSeconds(1f);
        SceneManager.UnloadSceneAsync(MenuScene);
        SceneManager.UnloadSceneAsync(MainScene);

        yield return new WaitForSeconds(1f);
        Destroy(cam);
        PlayMusic(0);
        SceneManager.LoadSceneAsync(MenuScene, LoadSceneMode.Additive);
    }

    private void Update()
    {
        Scene menuScene = SceneManager.GetSceneByPath(MenuScene);
        if (menuScene != null && menuScene.isLoaded)
        {
            SceneManager.SetActiveScene(menuScene);
        }

        Scene mainScene = SceneManager.GetSceneByPath(MainScene);
        if (mainScene != null && mainScene.isLoaded)
        {
            SceneManager.SetActiveScene(mainScene);
        }
        
    }

    public void MainSceneLoad()
    {
        StartCoroutine(MainSceneTimer());
    }

    public void MenuSceneLoad()
    {
        Time.timeScale = 1f;
        MenuScene = SceneUtility.GetScenePathByBuildIndex(2);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync(MenuScene, LoadSceneMode.Additive);

        PlayMusic(0);
    }

    IEnumerator MainSceneTimer()
    {
        MainScene = SceneUtility.GetScenePathByBuildIndex(3);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync(MainScene, LoadSceneMode.Additive);

        yield return new WaitForSeconds(0.5f);
        Debug.Log("test");
        PlayMusic(1);

        cubeAnimator = GameObject.Find("MainCube").GetComponent<MainCubeAnimations>();
        cubeAnimator.Main();
    }

    public void PlayMusic(int index)
    {
        audioManager = GameObject.Find("SimpleAudioManager").GetComponent<Manager>();
        audioManager.PlaySong(index);
    }
}
