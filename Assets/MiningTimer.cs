using System;
using UnityEngine;

public class MiningTimer : MonoBehaviour
{
    [SerializeField] float time;
    public float remainingMiningTime { get; private set; }

    public event Action OnTimeOver;

    // TODO: ¿”Ω√
    private void Start()
    {
        SetupTimer();
        GameManager.Instance.sceneTransitionManager.OnMiningTurnEnter += SetupTimer;
    }

    private void Update()
    {
        remainingMiningTime -= Time.deltaTime;
        if (remainingMiningTime < 0)
        {
            remainingMiningTime = 0;
            Over();
        }
    }

    private void Over()
    {
        print("¥‘ ¡◊¿Ω");
        Time.timeScale = 0;
        OnTimeOver?.Invoke();
    }

    private void SetupTimer()
    {
        remainingMiningTime = time;
        Time.timeScale = 1;
    }
}
