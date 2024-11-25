using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySkinObject", menuName = "ScriptableObjects/EnemySkinObject")]
public class EnemySkinObject : ScriptableObject
{
    [SerializeField] SaveFile saveFile;

    [Header("Skins")]
    public List<Material> materialsBody;
    public List<Material> materialsHealth;
    public Material Body;
    public Material Health;

    public void UpdateSkin()
    {
        Body = materialsBody[saveFile.ActiveEnemySkin];
        Health = materialsHealth[saveFile.ActiveEnemySkin];
    }
}
