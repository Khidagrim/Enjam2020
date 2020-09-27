using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
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
        gameHasStarted = true;
    }     

    public void Defeat()
    {
        UIManager.Instance.ShowHideDefeatScreen(true);
    } 

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }    
}
