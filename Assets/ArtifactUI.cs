using UnityEngine;

public class ArtifactUI : MonoBehaviour
{
    [SerializeField] private GameObject artifactPanel;
    [SerializeField] private GameObject resultPanel;
    public UIStacker uiStacker;

    public OreData coal;

    public void ShowArtifactPanel()
    {
        uiStacker.ShowPanel(artifactPanel);
    }

    public void MakeArtifact()
    {
        if (GameManager.Instance.inventory.GetItemCount(coal) >= 10)
        {
            GameManager.Instance.inventory.RemoveItem(coal, 10);
            uiStacker.ShowPanel(resultPanel);
            Debug.Log("Artifact Created!");
        }
    }
}
