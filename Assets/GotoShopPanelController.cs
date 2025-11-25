using UnityEngine;

public class GotoShopPanelController : MonoBehaviour
{
    [SerializeField] private GameObject gotoShopPanel;
    private void Start()
    {
        GameManager.Instance.miningTimer.OnTimeOver += ShowGotoshopPanel;
    }

    private void OnDisable()
    {
        GameManager.Instance.miningTimer.OnTimeOver -= ShowGotoshopPanel;
    }

    private void ShowGotoshopPanel()
    {
        gotoShopPanel.SetActive(true);
    }

    public void OnClick()
    {
        GameManager.Instance.sceneTransitionManager.StartTransition("Shop");
    }
}
