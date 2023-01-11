using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ControllerPicker : MonoBehaviour
{
    // Start is called before the first frame update

    // Poll every controller for button presses, assign players when a button is pressed
    [SerializeField] GameObject playerSlot1;

    void PollForInput()
    {
        foreach(Gamepad pad in Gamepad.all)
        {
            if(pad.buttonSouth.wasPressedThisFrame)
            {

            }
            else if(Keyboard.current.spaceKey.wasPressedThisFrame)
            {

            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
