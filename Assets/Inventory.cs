using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int money { get; private set; }
    private Dictionary<OreData, int> items = new();
    private Dictionary<ArtifactBase, int> artifacts = new();


    public event Action<OreData> OnItemAmountChanged;
    public event Action<int> OnMoneyAmountChanged;

    // 추가
    public void AddItem(OreData ore, int amount)
    {
        if (!items.ContainsKey(ore))
        {
            items[ore] = 0;
        }
        items[ore] += amount;

        print($"{ore.oreName} 아이템 {amount}개 추가. 현재 개수: {items[ore]}");
        OnItemAmountChanged?.Invoke(ore);
    }

    public void RemoveItem(OreData ore, int amount)
    {
        if (!items.ContainsKey(ore))
        {
            return;
        }
        items[ore] -= amount;

        print($"{ore.oreName} 아이템 {amount}개 삭제. 현재 개수: {items[ore]}");
        OnItemAmountChanged?.Invoke(ore);
    }

    // 조회
    public int GetItemCount(OreData ore)
    {
        if (!items.ContainsKey(ore))
            return 0;
        else
            return items[ore];
    }

    public void AddMoney(int value)
    {
        money += value;
        OnMoneyAmountChanged?.Invoke(money);
    }
}
