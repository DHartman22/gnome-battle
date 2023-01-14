using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlot : MonoBehaviour
{
    // Used as a visual representation of InputManager in the Input scene

    [SerializeField] Image awaitingInputSprite;

    [SerializeField] Image deviceIcon;
    [SerializeField] Sprite keyboardIcon;
    [SerializeField] Sprite gamepadIcon;

    [SerializeField] TextMeshProUGUI gamepadNameText;
    [SerializeField] PlayerId player;
    [SerializeField] string awaitingInputText;
    [SerializeField] bool awaitingInput = true;
    
    void UpdateUI()
    {
        if (InputManager.instance.inputList.ContainsKey((int)player) && awaitingInput)
        {
            gamepadNameText.text = InputManager.instance.inputList[(int)player].GetGamepadName() + "\nReady";
            awaitingInputSprite.enabled = false;
            deviceIcon.gameObject.SetActive(true);
            awaitingInput = false;

            if (InputManager.instance.inputList[(int)player].isKeyboard)
                deviceIcon.sprite = keyboardIcon;
            else
                deviceIcon.sprite = gamepadIcon;

            return;
        }

        if(!awaitingInput && !InputManager.instance.inputList.ContainsKey((int)player))
        {
            Clear();
        }
        
    }

    public void Clear()
    {
        awaitingInputSprite.enabled = true;
        deviceIcon.gameObject.SetActive(false);
        awaitingInput = true;
        gamepadNameText.text = awaitingInputText;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
}
