using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkin : MonoBehaviour
{
    [SerializeField] EnemySkinObject SkinObject;
    [SerializeField] MeshRenderer rendererBody;
    [SerializeField] MeshRenderer rendererHealth;

    private void Awake()
    {
        List<Material> bodyMats = new List<Material>();
        List<Material> healthMats = new List<Material>();

        bodyMats.Add(SkinObject.Body);
        healthMats.Add(SkinObject.Health);

        rendererBody.SetMaterials(bodyMats);
        rendererHealth.SetMaterials(healthMats);
    }
}
