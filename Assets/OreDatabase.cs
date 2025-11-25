using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OreDatabase", menuName = "Scriptable Objects/OreDatabase")]
public class OreDatabase : ScriptableObject
{
    [SerializeField]
    private OreData[] ores = Array.Empty<OreData>();

    public OreData[] GetOreListByFloor(int floor)
    {
        List<OreData> data = new();
        OreData ore;
        for (int i = 0; i < ores.Length; i++)
        {
            ore = ores[i];
            if (ore.appearFloorRange.x <= floor && floor <= ore.appearFloorRange.y)
                data.Add(ore);
        }
        return data.ToArray();
    }
}
