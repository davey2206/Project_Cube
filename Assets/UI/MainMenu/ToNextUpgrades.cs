using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNextUpgrades : MonoBehaviour
{
    [SerializeField] Animator Animator;
    [SerializeField] GameObject Next_1;
    [SerializeField] GameObject Next_2;

    public void Page_1()
    {
        Next_1.SetActive(true);
        Next_2.SetActive(false);

        Animator.SetTrigger("Page_1");
    }

    public void Page_2()
    {
        Next_1.SetActive(false);
        Next_2.SetActive(true);

        Animator.SetTrigger("Page_2");
    }
}
