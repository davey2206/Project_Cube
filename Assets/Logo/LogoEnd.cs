using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeScene());
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
