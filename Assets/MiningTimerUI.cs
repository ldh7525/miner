using TMPro;
using UnityEngine;

public class MiningTimerUI : MonoBehaviour
{
    MiningTimer miningTimer;
    TMP_Text miningTimerText;
    private float RemainingTime => miningTimer.remainingMiningTime;
    // TODO: юс╫ц
    private void Start()
    {
        miningTimerText = GetComponent<TMP_Text>();
        miningTimer = GameManager.Instance.miningTimer;
    }

    private void Update()
    {
        miningTimerText.text = RemainingTime.ToString("F2");
        if (RemainingTime <= 0)
        {
            miningTimerText.text = "";
        }
    }

}