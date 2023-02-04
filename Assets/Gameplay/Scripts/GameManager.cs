using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public enum GAME_STATE
{
    MAIN_MENU,
    GAME,
    PAUSED,
}

public class GameManager : MonoBehaviour
{
    GAME_STATE currentState = 0;
    GAME_STATE previousState = 0;

    public static GameManager _instance;

    public static event Action<GAME_STATE> OnGameStateChange;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Awake()
    {
        _instance = this;
    }

    public void setGameState(int nState)
    {

        _instance.previousState = currentState;
        _instance.currentState = (GAME_STATE)nState;
        Debug.Log("new state " + _instance.currentState.ToString());

        switch(currentState)
        {
            case GAME_STATE.MAIN_MENU:
                
            break;
            case GAME_STATE.GAME:
                
            break;
            case GAME_STATE.PAUSED:
              
            break;
            default:
            break;
               
        }

        OnGameStateChange?.Invoke(currentState);
    }

    GAME_STATE GetGameState()
    {
        return _instance.currentState;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

