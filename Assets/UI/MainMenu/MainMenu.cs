using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void Upgrade()
    {
        animator.SetTrigger("Upgrade");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        animator.SetTrigger("MainMenu");
    }
}
