using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public bool gameHasStarted;
    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        ScoreManager.Instance.Init();
        CharacterManager.Instance.Init();
        UIManager.Instance.Init();
        gameHasStarted = true;
    }

    public void Reset()
    {
        //CharacterManager.Instance.Reset();
        //CharacterManager.Instance.Reset();
    }        
    
}
