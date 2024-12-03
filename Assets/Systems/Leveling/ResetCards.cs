using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetCards : MonoBehaviour
{
    [SerializeField] GameObject RerollText;
    [SerializeField] GameObject Reroll;
    [SerializeField] GameObject SpawnPoint_1;
    [SerializeField] GameObject SpawnPoint_2;
    [SerializeField] GameObject SpawnPoint_3;
    [SerializeField] GameObject Background;

    public void Spawn()
    {
        GetComponent<Animator>().SetTrigger("Spawn");
    }

    public void DeleteCards()
    {
        GetComponent<Animator>().SetTrigger("DeSpawn");
        StartCoroutine(ResetTime());
    }

    public void ResetAllCards()
    {
        RerollText.SetActive(false);
        Reroll.SetActive(true);
        SpawnPoint_1.GetComponentInChildren<LevelAbility>().DestroySelf();
        SpawnPoint_2.GetComponentInChildren<LevelAbility>().DestroySelf();
        SpawnPoint_3.GetComponentInChildren<LevelAbility>().DestroySelf();
    }

    IEnumerator ResetTime()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.5f);
        ResetAllCards();
    }
}
