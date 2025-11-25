using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyTransition : MonoBehaviour
{
    public void LoadMining()
    {
        SceneManager.LoadScene("MiningScene");
    }
}
