using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Timer timer;
    public bool gameHasStarted;
    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    

    public void Init()
    {
        ScoreManager.Instance.Init();
        CharacterManager.Instance.Init();
        UIManager.Instance.Init();
        timer.Init();
        gameHasStarted = true;
    }     

    public void Defeat()
    {
        gameHasStarted = false;
        UIManager.Instance.ShowHideDefeatScreen(true);
    } 

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }    

    public void EndTheGame()
    {
        gameHasStarted = false;
        UIManager.Instance.ShowHideEndGame(true);
    }
}
