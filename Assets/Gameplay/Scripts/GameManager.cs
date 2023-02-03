using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

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

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                UnityEngine.Debug.Log("nae game manager pal");
            return _instance; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;    
    }

    public void setGameState(int nState)
    {
        previousState = currentState;
        currentState = (GAME_STATE)nState;
        UnityEngine.Debug.Log("something changed");
    }

    GAME_STATE GetGameState()
    {
        return currentState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

