using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimb : MonoBehaviour
{
    public PlayerId player;
    
    PlayerAction proposedAction;

    Vector2Int coords;
    // Sends PlayerActions to TickManager
    // 
    void CheckInput()
    {
        PlayerInput pInput = InputManager.instance.GetPlayerInput(player);
        Vector2Int move = pInput.GetMovementAxis();

        // Requires the button to be held down until the final frame of the tick for it to work
        // Maybe replace this with some kind of buffer later
        if(move != Vector2Int.zero)
        {
            proposedAction = new MoveAttemptAction(this, coords + move);
        }
        else
        {
            proposedAction = new IdleAction(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }
}
