using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<WaveList> Waves;

    private void Start()
    {
        StartCoroutine(SpawnerTimer());
    }

    IEnumerator SpawnerTimer()
    {
        int i = 0;
        while (true) 
        {
            Debug.Log(i);
            foreach (var enemy in Waves[i].enemyLists)
            {
                StartCoroutine(SpawnEnemy(enemy.TimeOfSpawn, enemy.Enemy, enemy.NumberOfSpawns));
            }
            yield return new WaitForSeconds(60);
            if (i < (Waves.Count - 1))
            {
                i++;
            }
            else
            {
                break;
            }
        }
    }

    IEnumerator SpawnEnemy(float SpawnTime, GameObject enemy, int NumberOfSpawn)
    {
        yield return new WaitForSeconds(SpawnTime);

        Vector3 posRightTop = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
        Vector3 pos = new Vector3();
        int y = 0;

        for (int i = 0; i < NumberOfSpawn; i++)
        {
            y++;
            switch (y)
            {
                case 1:
                    pos = new Vector3(Random.Range(posRightTop.x, -posRightTop.x), 0, posRightTop.z + 1);
                    break;
                case 2:
                    pos = new Vector3(Random.Range(posRightTop.x, -posRightTop.x), 0, -posRightTop.z - 1);
                    break;
                case 3:
                    pos = new Vector3(posRightTop.x + 1, 0, Random.Range(posRightTop.z, -posRightTop.z));
                    break;
                case 4:
                    pos = new Vector3(-posRightTop.x - 1, 0, Random.Range(posRightTop.x, -posRightTop.x));
                    break;
            }

            if (y == 4)
            {
                y = 0;
            }

            Instantiate(enemy, new Vector3(pos.x, 0, pos.z), Quaternion.Euler(20, 0, 20));
        }
    }
}
