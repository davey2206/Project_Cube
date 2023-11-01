using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpAnimation : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Animator>().SetTrigger("PopUp");
    }

    public void DisableButtons()
    {
        gameObject.SetActive(false);
    }
}
