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
                    ActivateAbilitiesOnClick(hit.transform.position);
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
