using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PauseMenu;
    public GameObject GameHUD;

    private void Awake()
    {
        GameManager.OnGameStateChange += GameManager_OnGameStateChange;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
