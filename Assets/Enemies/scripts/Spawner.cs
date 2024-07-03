using SimpleAudioManager;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Waves")]
    [SerializeField] AnimationCurve SpawnPoints;

    [Header("Enemies")]
    [SerializeField] List<WaveList> Waves;
    [SerializeField] GameObject Boss;

    [Header("UI")]
    [SerializeField] GameObject gameEnd;
    [SerializeField] TextMeshProUGUI gameStartText;

    [Header("PlayerStats")]
    [SerializeField] PlayerStats playerStats;

    Manager audioManager;
    int currentWave = 0;
    int spawnPoints;
    bool lastWaveDone = false;
    bool done = false;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        audioManager = GameObject.Find("SimpleAudioManager").GetComponent<Manager>();
    }

    private void Update()
    {
        if (lastWaveDone && GameObject.FindGameObjectsWithTag("Enemy").Count() == 0 && GameObject.FindGameObjectsWithTag("Boss").Count() == 0)
        {
            if (!done)
            {
                done = true;
                StartCoroutine(EndGame());
            }
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.5f);
        playerStats.AddCoins();
        gameEnd.SetActive(true);
        gameStartText.text = "Victory";
        audioManager.PlaySong(2);
        StopAllCoroutines();
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1f);
        while (currentWave < Waves.Count)
        {
            Vector3 posRightTop = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
            Vector3 pos = new Vector3();
            int y = 0;
            int cycle = 0;

            while (Waves[currentWave].cycles != cycle)
            {
                spawnPoints = (int)SpawnPoints.Evaluate(currentWave);

                while (spawnPoints > 0)
                {
                    Enemy enemy = Waves[currentWave].enemies[Random.Range(0, Waves[currentWave].enemies.Count)];

                    y++;
                    switch (y)
                    {
                        case 1:
                            pos = new Vector3(Random.Range(posRightTop.x, -posRightTop.x), 0, posRightTop.z + 1.5f);
                            break;
                        case 2:
                            pos = new Vector3(Random.Range(posRightTop.x, -posRightTop.x), 0, -posRightTop.z - 1.5f);
                            break;
                        case 3:
                            pos = new Vector3(posRightTop.x + 1.5f, 0, Random.Range(posRightTop.z, -posRightTop.z));
                            break;
                        case 4:
                            pos = new Vector3(-posRightTop.x - 1.5f, 0, Random.Range(posRightTop.x, -posRightTop.x));
                            break;
                    }

                    if (y == 4)
                    {
                        y = 0;
                    }

                    spawnPoints -= enemy.Cost;
                    Instantiate(enemy, new Vector3(pos.x, 0, pos.z), Quaternion.Euler(20, 0, 20));
                }

                cycle++;
                yield return new WaitForSeconds(Waves[currentWave].delay);
            }
           
            currentWave++;
        }

        yield return new WaitForSeconds(10f);

        Instantiate(Boss);
        lastWaveDone = true;
    }
}
