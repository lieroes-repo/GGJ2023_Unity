using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PauseMenu;
    public GameObject GameHUD;

    public static MenuManager Instance;
  

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        GameManager.OnGameStateChange += GameManager_OnGameStateChange;
    }

    public MenuManager getMenuManager()
    {
        return Instance;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= GameManager_OnGameStateChange;
    }

    private void GameManager_OnGameStateChange(GAME_STATE nstate)
    {
        MainMenu?.SetActive(nstate == GAME_STATE.MAIN_MENU);
        GameHUD?.SetActive(nstate == GAME_STATE.GAME);
        PauseMenu?.SetActive(nstate == GAME_STATE.PAUSED);
    }

    public void TogglePause()
    {
        if (FindObjectOfType<GameManager>().getGameManager().GetGameState() != GAME_STATE.PAUSED)
            FindObjectOfType<GameManager>().getGameManager().setGameState((int)GAME_STATE.PAUSED);
        else FindObjectOfType<GameManager>().getGameManager().RevertGameState();
    }

    public void Play()
    {
        FindObjectOfType<GameManager>().getGameManager().setGameState((int)GAME_STATE.GAME);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameplay()
    {
        Debug.Log("Menu manager gameplay start");
        FindObjectOfType<GameState>().BeginPlay();
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!)");
        Application.Quit();
    }
    
}
