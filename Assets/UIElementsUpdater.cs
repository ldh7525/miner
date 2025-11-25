using TMPro;
using UnityEditor;
using UnityEngine;

public class UIElementsUpdater : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private TMP_Text coal, iron, gold;

    // TODO: ÄÚµå 
    private void Start()
    {
        inventory = GameManager.Instance.inventory;
        inventory.OnItemAmountChanged += UpdateOreUI;

    }

    private void UpdateOreUI(OreData data)
    {
        switch (data.oreName)
        {
            case "Coal":
                coal.text = inventory.GetItemCount(data).ToString();
                break;
            case "Iron":
                iron.text = inventory.GetItemCount(data).ToString();
                break;
            case "Gold":
                gold.text = inventory.GetItemCount(data).ToString();
                break;
            default:
                Debug.LogError("Unknown ore type: " + data.oreName);
                break;
        }
    }
}
