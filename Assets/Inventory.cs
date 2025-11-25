using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public struct InventoryItem
    {
        public OreData ore;
        public int quantity;
    }

    private List<InventoryItem> items = new();

    // 추가
    public void AddItem(OreData ore, int amount)
    {
        InventoryItem existing = items.Find(x => x.ore == ore);
        if (existing.ore != null)
            items[items.IndexOf(existing)].quantity += amount;
        else
            items.Add(new InventoryItem { ore = ore, quantity = amount });
    }

    // 조회
    public InventoryItem? GetItem(OreData ore)
    {
        return items.Find(x => x.ore == ore);
    }
}
