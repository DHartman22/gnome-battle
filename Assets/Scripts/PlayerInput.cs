using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput
{
    // An interface for any input device, used by InputManager 
    public bool isKeyboard = false;
    [SerializeField] Gamepad pad;
    [SerializeField] float deadzone;
    public PlayerInput(Gamepad pad)
    {
        isKeyboard = false;
        this.pad = pad;
    }

    public PlayerInput(Keyboard kb)
    {
        isKeyboard = true;
        pad = null;
    }

    public string GetGamepadName()
    {
        if (isKeyboard) 
            return "Keyboard";
        else
            return pad.name;
    }

    public int GetDeviceID()
    {
        if (isKeyboard)
            return Keyboard.current.deviceId;
        else
            return pad.deviceId;
    }

    public Vector2Int GetMovementAxis()
    {
        Vector2Int outputVector = Vector2Int.zero;
        if(isKeyboard)
        {
            // Ugly but works
            if(Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                outputVector.y = 1;
            else if(Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                outputVector.y = -1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                outputVector.x = 1;
            else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                outputVector.x = -1;
        }
        else
        {
            //Prioritize stick if magnitude is higher than deadzone, otherwise check dpad
            Debug.Log(pad.leftStick.EvaluateMagnitude());
            outputVector = new Vector2Int((int)pad.dpad.x.ReadValue(), (int)pad.dpad.y.ReadValue());
        }
        return outputVector;
    }
}
