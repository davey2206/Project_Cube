using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HitEffect : MonoBehaviour
{
    [SerializeField] Volume volume;
    [SerializeField] int Steps;

    VolumeProfile profile;

    float vignetteIntensity = 0.1f;
    float chromaticAberrationIntensity = 0.05f;

    private void Start()
    {
        profile = volume.profile;
    }

    public void Hit()
    {
        Vignette vignette;
        ChromaticAberration chromaticAberration;

        vignetteIntensity += 0.2f;
        chromaticAberrationIntensity += 0.15f;

        if (profile.TryGet<Vignette>(out vignette))
        {
            vignette.color.Override(Color.red);
            vignette.intensity.Override(vignetteIntensity);
        }

        if (profile.TryGet<ChromaticAberration>(out chromaticAberration))
        {
            chromaticAberration.intensity.Override(chromaticAberrationIntensity);
        }

        StopAllCoroutines();
        StartCoroutine(ResetProfile());
    }

    IEnumerator ResetProfile()
    {
        Vignette vignette;
        ChromaticAberration chromaticAberration;

        float StepVignette = vignetteIntensity / Steps;
        float StepChromaticAberration = chromaticAberrationIntensity / Steps;

        for (int i = 0; i < Steps; i++)
        {
            yield return new WaitForSeconds(0.01f);

            if (profile.TryGet<Vignette>(out vignette))
            {
                vignetteIntensity -= StepVignette;

                if (vignetteIntensity <= 0.1f)
                {
                    vignetteIntensity = 0.1f;
                }

                vignette.color.Override(Color.black);
                vignette.intensity.Override(vignetteIntensity);
            }

            if (profile.TryGet<ChromaticAberration>(out chromaticAberration))
            {
                chromaticAberrationIntensity -= StepChromaticAberration;

                if (chromaticAberrationIntensity <= 0.05f)
                {
                    chromaticAberrationIntensity = 0.05f;
                }

                chromaticAberration.intensity.Override(chromaticAberrationIntensity);
            }
        }


        if (profile.TryGet<Vignette>(out vignette))
        {
            vignette.color.Override(Color.black);
        }

    }
}
