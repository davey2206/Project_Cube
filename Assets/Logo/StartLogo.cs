using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLogo : MonoBehaviour
{
    [SerializeField] GameObject logo;

    private IEnumerator Start()
    {
        Cursor.visible = false;
        yield return new WaitForSeconds(1);
        Instantiate(logo);
    }
}
