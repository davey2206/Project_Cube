using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<WaveList> Waves;
    [SerializeField] List<Enemy> enemies;
    [SerializeField] PlayerStats playerStats;

    [Header("UI")]
    [SerializeField] GameObject gameEnd;
    [SerializeField] TextMeshProUGUI gameStartText;

    int currentWave = 0;
    int spawnPoints;
    bool lastWaveDone = false;
    bool Done = false;
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        if (lastWaveDone && !Done)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Count() == 0)
            {
                Done = true;
                playerStats.AddCoins();
                gameEnd.SetActive(true);
                gameStartText.text = "Victory";
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (currentWave < Waves.Count)
        {
            spawnPoints = Waves[currentWave].spawnPoints;
            List<Enemy> enemiesThatCanSpawn = new List<Enemy>();

            foreach (Enemy enemy in enemies)
            {
                if ((int)enemy.difficultyRange.x <= Waves[currentWave].difficulty && Waves[currentWave].difficulty <= (int)enemy.difficultyRange.y)
                {
                    enemiesThatCanSpawn.Add(enemy);
                }
            }

            Vector3 posRightTop = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
            Vector3 pos = new Vector3();
            int y = 0;

            while (spawnPoints > 0)
            {
                Enemy enemy = enemiesThatCanSpawn[Random.Range(0, enemiesThatCanSpawn.Count)];

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

            yield return new WaitForSeconds(Waves[currentWave].waveLength);
            currentWave++;
        }

        lastWaveDone = true;
    }
}
