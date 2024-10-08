using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStormSpawner : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] BulletMovement Bullet;
    [SerializeField] ability ability;

    [SerializeField] List<AudioClip> audioClips;
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioManeger audioManeger;

    int Sound = 1;
    float rot = 0;

    public IEnumerator spawnBullet(float attack, int numberOfBullets, int extraBullets)
    {
        while (true)
        {
            PlaySound();
            for (int i = 0; i < numberOfBullets; i++)
            {
                float baseAttack = playerStats.GetAttack() * attack;
                var b = Instantiate(Bullet, Vector3.zero, Quaternion.Euler(0, rot, 0));
                b.SetAttack(baseAttack + playerStats.GetAbilityDamage(baseAttack));
                rot = rot + 25;
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(0.5f);

            if (ability.Evolved)
            {
                for (int i = 0; i < extraBullets; i++)
                {
                    float baseAttack = playerStats.GetAttack() * attack;
                    var b = Instantiate(Bullet, Vector3.zero, Quaternion.Euler(0, rot, 0));
                    b.SetAttack(baseAttack + playerStats.GetAbilityDamage(baseAttack));
                    rot = rot + (360 / extraBullets);
                }
            }

            yield return new WaitForSeconds(playerStats.GetCooldown(4.5f));
        }
    }

    public void PlaySound()
    {
        if (audioManeger.CanSpawnAudio())
        {
            switch (Sound)
            {
                case 1:
                    AudioSource.PlayOneShot(audioClips[0]);
                    break;
                case 2:
                    AudioSource.PlayOneShot(audioClips[1]);
                    break;
                case 3:
                    AudioSource.PlayOneShot(audioClips[2]);
                    break;
                case 4:
                    AudioSource.PlayOneShot(audioClips[3]);
                    break;
            }
        }
    }

    public void Stats(int level)
    {
        switch (level)
        {
            case 1:
                Sound = 1;
                StopAllCoroutines();
                StartCoroutine(spawnBullet(0.5f, 20, 5));
                break;
            case 2:
                Sound = 2;
                StopAllCoroutines();
                StartCoroutine(spawnBullet(0.5f, 30, 10));
                break;
            case 3:
                Sound = 2;
                StopAllCoroutines();
                StartCoroutine(spawnBullet(0.5f, 40, 15));
                break;
            case 4:
                Sound = 3;
                StopAllCoroutines();
                StartCoroutine(spawnBullet(0.5f, 50, 20));
                break;
            case 5:
                Sound = 4;
                StopAllCoroutines();
                StartCoroutine(spawnBullet(0.5f, 60, 25));
                break;
        }
    }
}
