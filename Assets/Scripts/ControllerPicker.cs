using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ControllerPicker : MonoBehaviour
{
    // Start is called before the first frame update

    // Poll every controller for button presses, assign players to InputManager when the south button/space is pressed
    [SerializeField] GameObject playerSlot1;

    void PollForInput()
    {
        foreach(Gamepad pad in Gamepad.all)
        {
            if(pad.buttonSouth.wasPressedThisFrame)
                 InputManager.instance.AddPlayerAttempt(new PlayerInput(pad));
            if (pad.buttonNorth.wasPressedThisFrame)
                InputManager.instance.RemovePlayerAttempt(pad.deviceId);
        }
        // Needs to be separate, if no controllers are connected then this would never run
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            InputManager.instance.AddPlayerAttempt(new PlayerInput(Keyboard.current));
        if(Keyboard.current.shiftKey.wasPressedThisFrame)
            InputManager.instance.RemovePlayerAttempt(Keyboard.current.deviceId);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PollForInput();
    }
}
