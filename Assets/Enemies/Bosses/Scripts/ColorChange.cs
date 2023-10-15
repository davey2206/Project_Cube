using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] Renderer rendererBody;
    [SerializeField] Renderer rendererCore;

    [SerializeField] Color color1;
    [SerializeField] Color color2;

    public bool ColorTrue;

    private void Start()
    {
        ColorTrue = false;
    }

    private void Update()
    {
        if (!ColorTrue)
        {
            ChangeToColor1();
        }

        if (ColorTrue)
        {
            ChangeToColor2();
        }
    }


    public void ChangeToColor1()
    {
        rendererBody.material.color= color1;
        rendererCore.material.color= color1;
    }

    public void ChangeToColor2()
    {
        rendererBody.material.color = color2;
        rendererCore.material.color = color2;
    }
}
