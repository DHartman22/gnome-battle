using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput
{
    // An interface for any input device, used by InputManager 
    public bool isKeyboard = false;
    [SerializeField] Gamepad pad;

    PlayerInput(Gamepad pad)
    {
        isKeyboard = false;
        this.pad = pad;
    }

    PlayerInput(Keyboard kb)
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
}
