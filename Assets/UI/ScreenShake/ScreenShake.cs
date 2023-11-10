using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] ScreenShakeObject screenShake;
    CinemachineVirtualCamera cam;

    private void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        StartCoroutine(ResetShake());

        screenShake.Amplitude = 0;
        screenShake.Frequency = 1;
        screenShake.SpeedOfDecay = 1;
    }
    // Update is called once per frame
    void Update()
    {
        SetShake();
    }

    public void SetShake()
    {
        CinemachineBasicMultiChannelPerlin perlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = screenShake.Amplitude;
        perlin.m_FrequencyGain = screenShake.Frequency;
    }

    public IEnumerator ResetShake()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (screenShake.Amplitude > 0)
            {
                screenShake.Amplitude -= screenShake.SpeedOfDecay;
            }
            else
            {
                screenShake.Amplitude = 0;
                screenShake.Frequency = 1;
                screenShake.SpeedOfDecay = 1;
            }
        }
    }
}
