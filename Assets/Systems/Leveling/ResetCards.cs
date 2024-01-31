using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetCards : MonoBehaviour
{
    [SerializeField] GameObject SpawnPoint_1;
    [SerializeField] GameObject SpawnPoint_2;
    [SerializeField] GameObject SpawnPoint_3;
    [SerializeField] GameObject Background;

    public void AddReset()
    {
        Background.SetActive(true);
        SpawnPoint_1.GetComponentInChildren<Button>().onClick.AddListener(DeleteCards);
        SpawnPoint_2.GetComponentInChildren<Button>().onClick.AddListener(DeleteCards);
        SpawnPoint_3.GetComponentInChildren<Button>().onClick.AddListener(DeleteCards);
    }

    public void DeleteCards()
    {
        Background.SetActive(false);
        SpawnPoint_1.GetComponentInChildren<LevelAbility>().DestroySelf();
        SpawnPoint_2.GetComponentInChildren<LevelAbility>().DestroySelf();
        SpawnPoint_3.GetComponentInChildren<LevelAbility>().DestroySelf();

        StartCoroutine(ResetTime());
    }

    IEnumerator ResetTime()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1;
    }
}
