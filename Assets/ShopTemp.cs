using UnityEngine;

public class ShopTemp : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private UIStacker UIStacker;

    public void ShowShopPanel()
    {
        UIStacker.ShowPanel(shopPanel);
    }

    public void Sell(OreData data)
    {
        Inventory inventoryRef = GameManager.Instance.inventory;
        if (inventoryRef.GetItemCount(data) >= 10)
        {
            inventoryRef.RemoveItem(data, 1);
            inventoryRef.AddMoney(10);
        }
    }
}
