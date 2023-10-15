using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainCubeAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject cube;

    public bool MainRot;
    bool started;
    float rotationTime = 0.5f;
    float startTime;
    float currentTime;
    Quaternion targetRotation;
    Quaternion startRotation;

    public void Menu()
    {
        animator.SetTrigger("Menu");
    }

    public void Upgrades()
    {
        animator.SetTrigger("Upgrades");
    }

    public void Main()
    {
        animator.SetTrigger("Main");
    }

    public void BackMenu()
    {
        animator.SetTrigger("BackMenu");
    }

    private void Start()
    {
        MainRot = false;
        started= false;
    }

    private void Update()
    {
        if (MainRot)
        {
            if (!started)
            {
                StartRotation();
            }
            Rotation();
        }
        else
        {
            started = false;
        }
        
    }

    void StartRotation()
    {
        targetRotation = Quaternion.Euler(20, 0, 20);
        startRotation = cube.transform.rotation;
        startTime = Time.time;
        currentTime = startTime;
        started = true;
    }

    void Rotation()
    {
        currentTime += Time.deltaTime;
        cube.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, (currentTime - startTime) / rotationTime);
    }
}
