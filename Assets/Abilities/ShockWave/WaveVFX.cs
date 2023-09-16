using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WaveVFX : MonoBehaviour
{
    [SerializeField] VisualEffect vfx;
    [SerializeField] float Duration;
    [SerializeField] Color color;
    float SizeOfVFX;
    float timeElapsed;

    private void Start()
    {
        vfx.SetVector4("Color", color);
    }
    // Update is called once per frame
    void Update()
    {
        SizeOfVFX = Mathf.Lerp(100, 0, timeElapsed / Duration);
        timeElapsed += Time.deltaTime;
        vfx.SetFloat("Size", SizeOfVFX);
    }
}
