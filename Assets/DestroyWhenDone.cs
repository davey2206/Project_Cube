using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenDone : MonoBehaviour
{
    [SerializeField] float Time;
    [SerializeField] bool isAudio;
    [SerializeField] AudioManeger audioManeger;

    // Start is called before the first frame update
    void Start()
    {
        if (isAudio)
        {
            audioManeger.AudioSources++;
            StartCoroutine(RemoveAuido());
        }

        Destroy(gameObject, Time);
    }

    IEnumerator RemoveAuido()
    {
        yield return new WaitForSeconds(Time - 0.1f);
        audioManeger.AudioSources--;
    }
}
