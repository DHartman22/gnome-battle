using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerActionType
{
    ACTION_IDLE,
    ACTION_MOVE_ATTEMPT,
    ACTION_BUMP,
    ACTION_RETRACT
}

public abstract class PlayerAction
{
    public abstract void Execute();
    public abstract void ExecuteLoop();

    public abstract void Complete();


    public PlayerActionType actionType;
    public PlayerLimb limb;
    public bool completed = false;
}

public class MoveAttemptAction : PlayerAction
{
    public Vector2Int targetCellCoords;
    public MoveAttemptAction(PlayerLimb limb, Vector2Int targetCellCoords)
    {
        this.targetCellCoords = targetCellCoords;
        this.limb = limb;
        
    }


    public override void Execute()
    {
        // Move
    }

    public override void ExecuteLoop()
    {
        Complete();
    }
    public override void Complete()
    {
        completed = true;
    }
}
public class IdleAction : PlayerAction
{
    PlayerLimb limb;
    public IdleAction(PlayerLimb limb)
    {
        this.limb = limb;
    }


    public override void Execute()
    {
        // Do nothing
    }

    public override void ExecuteLoop()
    {
        Complete();
    }
    public override void Complete()
    {
        completed = true;
    }
}
