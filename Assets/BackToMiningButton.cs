using UnityEngine;

public class BackToMiningButton : MonoBehaviour
{
    public void BackToMining()
    {
        GameManager.Instance.sceneTransitionManager.StartTransition("MiningScene");
    }
}
