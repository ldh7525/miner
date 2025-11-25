using TMPro;
using UnityEngine;

public class ShopUIElementsUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;

    private void Start()
    {
        GameManager.Instance.inventory.OnMoneyAmountChanged += UpdateMoneyText;
        UpdateMoneyText(GameManager.Instance.inventory.money);
    }

    private void UpdateMoneyText(int value)
    {
        moneyText.text = "µ·: " + value.ToString();
    }
}
