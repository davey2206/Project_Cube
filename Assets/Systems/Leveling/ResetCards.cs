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
        SpawnPoint_1.GetComponentInChildren<Button>().onClick.AddListener(DeleteCards);
        SpawnPoint_2.GetComponentInChildren<Button>().onClick.AddListener(DeleteCards);
        SpawnPoint_3.GetComponentInChildren<Button>().onClick.AddListener(DeleteCards);
        GetComponent<Animator>().SetTrigger("Spawn");
    }

    public void DeleteCards()
    {
        GetComponent<Animator>().SetTrigger("DeSpawn");
        StartCoroutine(ResetTime());
    }

    IEnumerator ResetTime()
    {
        yield return new WaitForSeconds(0.5f);
        SpawnPoint_1.GetComponentInChildren<LevelAbility>().DestroySelf();
        SpawnPoint_2.GetComponentInChildren<LevelAbility>().DestroySelf();
        SpawnPoint_3.GetComponentInChildren<LevelAbility>().DestroySelf();
        Time.timeScale = 1;
    }
}
