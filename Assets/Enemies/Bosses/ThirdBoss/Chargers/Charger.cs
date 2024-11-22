using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{
    [SerializeField] ChargeCubeMovement ChargeCube;
    [SerializeField] Transform Target;
    [SerializeField] float SpawnDelay = 5;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnDelay);
            ChargeCubeMovement cube = Instantiate(ChargeCube, transform.position, Quaternion.identity);
            cube.SetTarget(Target.position);
        }
    }
}
