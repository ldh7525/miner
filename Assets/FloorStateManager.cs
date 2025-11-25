using UnityEngine;

public class FloorStateManager : Singleton<FloorStateManager>
{
    public int currentFloor { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        currentFloor = 1;
    }

    private void Start()
    {
        GameManager.Instance.sceneTransitionManager.OnMiningTurnEnter += IncreaseFloor;
    }

    private void IncreaseFloor()
    {
        currentFloor++;
    }
}
