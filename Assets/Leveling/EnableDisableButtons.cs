using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableDisableButtons : MonoBehaviour
{
    [SerializeField] List<Button> buttons;
    private void OnEnable()
    {
        foreach (var button in buttons)
        {
            button.enabled = false;
            StartCoroutine(EnableButtons());
        }
    }

    IEnumerator EnableButtons()
    {
        yield return new WaitForSecondsRealtime(1);
        foreach (var button in buttons)
        {
            button.enabled = true;
        }
    }
}
