using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


using AK;
using Unity.VisualScripting;

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

    public static event Action<GAME_STATE> OnGameStateChange;

    //wwise
    public AK.Wwise.Event playBackgroundEvent;

    public AK.Wwise.Event muteEvent;
    public AK.Wwise.Event unmuteEvent;

    public Button muteButton;

    private bool muteButtonPressed = false;
    // Start is called before the first frame update
    void Start()
    {
    
    // play background sound. Included this in this script cause this script is called at the start of the game
    playBackgroundEvent.Post(gameObject);

    
    }

    public GameManager getGameManager()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;

        DontDestroyOnLoad(this);

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        Button btn = muteButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log("loaded main Scene");
        //SceneManager.MergeScenes(arg0,SceneManager.GetActiveScene());
        SceneManager.SetActiveScene(arg0);
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
                if (previousState == GAME_STATE.MAIN_MENU)
                {
                    SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
                    Debug.Log("loading Main Scene");
                }

                break;
            case GAME_STATE.PAUSED:
              
            break;
            default:
            break;
               
        }

        OnGameStateChange?.Invoke(currentState);
    }

    public GAME_STATE GetGameState()
    {
        return _instance.currentState;
    }

    public void RevertGameState()
    {
        setGameState((int)previousState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        if (muteButtonPressed == false)
        {
            muteEvent.Post(gameObject);
            muteButtonPressed = true;
            Debug.Log("sound muted");
        }
        else
        {
            //unmute sound
            unmuteEvent.Post(gameObject);
            muteButtonPressed = false;
            Debug.Log("sound Unmuted");
        }
    }
}

