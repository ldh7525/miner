using System;
using UnityEngine;

public enum TurnState
{
    Mining,
    Shop
}

public class TurnManager : Singleton<TurnManager>
{
    public event Action OnMiningTurnEnter;
    public event Action OnShopTurnEnter;
    private TurnState currentTurnState;


    private void ChangeTurn()
    {
        if (currentTurnState == TurnState.Mining)
        {
            OnShopTurnEnter?.Invoke();
            currentTurnState = TurnState.Shop;
            // ¾À º¯°æ µî
        }
        else if (currentTurnState == TurnState.Shop)
        {
            OnMiningTurnEnter?.Invoke();
            currentTurnState = TurnState.Mining;
        }
    }

}
