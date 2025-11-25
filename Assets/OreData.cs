using UnityEngine;

[CreateAssetMenu(fileName = "OreData", menuName = "Scriptable Objects/OreData")]
public class OreData : ScriptableObject
{
    public Sprite sprite;
    public string oreName;
    public Vector2Int appearFloorRange;
}
