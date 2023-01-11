using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerId
{
    PLAYER_1 = 0,
    PLAYER_2 = 1,
    PLAYER_3 = 2,
    PLAYER_4 = 3
}

public class InputManager : MonoBehaviour
{
    // Contains and manages PlayerInput objects

    static public InputManager instance = null;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [SerializeField] public Dictionary<int, PlayerInput> inputList;
    public int maxPlayers = 4;
    public int currentPlayers = 0;
    

    public bool AddPlayerAttempt(PlayerInput newInput)
    {
        if (inputList.Count >= maxPlayers)
            return false;

        if (ContainsDeviceID(newInput.GetDeviceID()))
            return false;

        inputList.Add(LowestUnusedPlayerID(), newInput);
        currentPlayers++;
        return true;
    }

    public bool RemovePlayerAttempt(int deviceId)
    {
        
        foreach (KeyValuePair<int, PlayerInput> input in inputList)
        {
            if (input.Value.GetDeviceID() == deviceId)
            {
                inputList.Remove(input.Key);
                return true;
            }
        }


        return false;
    }

    bool ContainsDeviceID(int deviceId)
    {
        foreach (KeyValuePair<int, PlayerInput> input in inputList)
        {
            if (input.Value.GetDeviceID() == deviceId)
                return true;
        }
        return false;
    }

    // Useful for when players press east button/escape to exit and slot 1 is open but not slot 0 or 2
    int LowestUnusedPlayerID()
    {
        for (int i = 0; i < maxPlayers; i++)
        {
            if(!inputList.ContainsKey(i))
                return i;
        }
        return -1;
    }

    public void DebugPrintInputList()
    {
        int i = 0;
        foreach(KeyValuePair<int, PlayerInput> input in inputList)
        {
            Debug.Log(i + ":" + input.Value.GetGamepadName());
            i++;
        }
        
    }

    void CheckForDisconnects()
    {
        foreach (KeyValuePair<int, PlayerInput> input in inputList)
        {
            if(InputSystem.GetDeviceById(input.Value.GetDeviceID()) == null)
            {
                // Panic
                Debug.LogError("Player " + input.Key + " using device " + input.Value.GetGamepadName() + " has been disconnected.");
                // Load this scene additively if the input scene isn't already open?
            }
        }
    }

    public PlayerInput GetPlayerInput(PlayerId id)
    {
        return inputList[(int)id];
    }

    // Start is called before the first frame update
    void Start()
    {
        inputList = new Dictionary<int, PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.qKey.wasPressedThisFrame)
        {
            DebugPrintInputList();
        }
        CheckForDisconnects();
    }
}
