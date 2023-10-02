using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] PlayerStats playerStats;
    [SerializeField] abilitiesObject abilities;

    [SerializeField] GameObject AttackVFX;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        StartCoroutine(Attack());
    }


    public void ActivateAbilitiesOnClick(Vector3 pos)
    {
        foreach (var abilitie in abilities.abilities)
        {
            if (abilitie.abilityType == AbilityTypes.Click && abilitie.Active == true)
            {
                abilitie.Ability.Invoke(abilitie.Level, pos);
            }
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(playerStats.GetAttackSpeed());
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            Vector3 Worldpos = cam.ScreenToWorldPoint(Input.mousePosition);

            Instantiate(AttackVFX, new Vector3(Worldpos.x, 0, Worldpos.z), Quaternion.identity);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 7))
            {
                
                if (hit.transform.CompareTag("Enemy"))
                {
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    enemy.TakeDamage(playerStats.GetAttack());

                    Vector3 pos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, 0, cam.ScreenToWorldPoint(Input.mousePosition).z);
                    ActivateAbilitiesOnClick(pos);
                }
            }
        }
    }
}
