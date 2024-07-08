using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "abilitiesObject", menuName = "ScriptableObjects/AbilitiesObject")]
public class abilitiesObject : ScriptableObject
{
    public List<ability> abilities;
}
