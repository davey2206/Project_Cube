using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] PlayerStats playerStats;
    [SerializeField] abilitiesObject abilities;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

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
}
