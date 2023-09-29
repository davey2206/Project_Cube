using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "ScriptableObjects/Upgrade")]
public class Upgrade : ScriptableObject
{
    public string Name;
    public Vector2 Unlocks;
    public List<int> Costs;

    public string getUnlock()
    {
        return Unlocks.x.ToString() + " | " + Unlocks.y.ToString();
    }

    public string getCost()
    {
        string cost = "----";
        if ((int)Unlocks.x != (int)Unlocks.y)
        {
            cost = Costs[(int)Unlocks.x].ToString();
        }
        return cost;
    }
}
