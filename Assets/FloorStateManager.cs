using UnityEngine;

public class FloorStateManager : Singleton<FloorStateManager>
{
    [SerializeField] private OreDatabase database;

    public int currentFloor;

    // ¸¶ÀÌ´× ÅÏÀ¸·Î ¹Ù²ð ¶§
    private void EnterMining()
    {

    }

    public OreData[] GetCurrentFloorOres()
    {
        return database.GetOreListByFloor(currentFloor);
    }
}
