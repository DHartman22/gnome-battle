using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickManager : MonoBehaviour
{
    // A "Tick" is effectively a turn where all players move at the same time
    // This script collects actions from each PlayerLimb, and resolves any actions it receives at the end of each tick
    // 

    [SerializeField] float timeBetweenTicks = 0.5f;
    [SerializeField] float tickElapsedTime = 0.0f;

    List<PlayerAction> actionsThisTick;
    [SerializeField] int currentTick = 0;
    [SerializeField] List<PlayerLimb> playerLimbs;
    void RequestPlayerActions()
    {

    }

    void CheckPlayerActions()
    {
        // Looks for any MoveAttemptActions targeting the same tile and replaces both with BumpActions
        List<Vector2Int> targetCells = new List<Vector2Int>();
        Dictionary<Vector2Int, PlayerId> targets = new Dictionary<Vector2Int, PlayerId>();

        foreach (MoveAttemptAction action in actionsThisTick)
        {
            targets.Add(action.targetCellCoords, action.limb.player);
        }

    }

    void ResolvePlayerActions()
    {

    }

    void NewTick()
    {
        actionsThisTick.Clear();
        currentTick++;

        // This carries over any potential overflow time to the next tick
        // e.g. if tickElapsedTime = 0.255f, the next tick starts at tickElapsedTime = 0.005f
        // Might be completely unnecessary but won't hurt
        tickElapsedTime -= timeBetweenTicks; 
    }

    void CheckForTickCompletion()
    {
        if()
    }

    // Start is called before the first frame update
    void Start()
    {
        actionsThisTick = new List<PlayerAction>();
        playerLimbs = new List<PlayerLimb>();
        playerLimbs.AddRange(GameObject.FindObjectsOfType<PlayerLimb>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
