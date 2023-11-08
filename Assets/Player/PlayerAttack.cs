using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] GameObject AttackVFX;
    [SerializeField] Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (playerStats.alive)
        {
            yield return new WaitForSeconds(playerStats.GetAttackSpeed());

            Vector3 Worldpos = cam.ScreenToWorldPoint(Input.mousePosition);

            Instantiate(AttackVFX, new Vector3(Worldpos.x, 0, Worldpos.z), Quaternion.identity);
        }
    }
}
