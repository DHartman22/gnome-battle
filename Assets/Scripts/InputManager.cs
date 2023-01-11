using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    static public InputManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    [SerializeField] List<PlayerInput> inputList;
    public int maxPlayers = 4;

    public void DebugPrintInputList()
    {
        int i = 0;
        foreach(PlayerInput input in inputList)
        {
            Debug.Log(i + ":" + input.GetGamepadName());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        inputList = new List<PlayerInput>(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
