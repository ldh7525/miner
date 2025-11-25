using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public Inventory inventory;
    public FloorStateManager floorStateManager;
    public MiningTimer miningTimer;
    public SceneTransitionManager sceneTransitionManager;
}
