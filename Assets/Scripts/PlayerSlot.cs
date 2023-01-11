using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSlot : MonoBehaviour
{
    // Used as a visual representation of InputManager in the Input scene

    [SerializeField] SpriteRenderer awaitingInputSprite;

    [SerializeField] SpriteRenderer deviceIcon;
    [SerializeField] Sprite keyboardIcon;
    [SerializeField] Sprite gamepadIcon;

    [SerializeField] TextMeshProUGUI gamepadNameText;
    [SerializeField] int playerIndex = 0; // 0 = P1, 1 = P2, etc 
    [SerializeField] string awaitingInputText;
    [SerializeField] bool awaitingInput = true;
    
    void UpdateUI()
    {
        if (InputManager.instance.inputList.ContainsKey(playerIndex) && awaitingInput)
        {
            gamepadNameText.text = InputManager.instance.inputList[playerIndex].GetGamepadName() + "\nReady";
            awaitingInputSprite.enabled = false;
            deviceIcon.gameObject.SetActive(true);
            awaitingInput = false;

            if (InputManager.instance.inputList[playerIndex].isKeyboard)
                deviceIcon.sprite = keyboardIcon;
            else
                deviceIcon.sprite = gamepadIcon;

            return;
        }

        if(!awaitingInput && !InputManager.instance.inputList.ContainsKey(playerIndex))
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
