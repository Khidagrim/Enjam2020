using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        CharacterManager.Instance.Init();
        UIManager.Instance.Init();
    }

    public void Reset()
    {
        //CharacterManager.Instance.Reset();
        //CharacterManager.Instance.Reset();
    }        
    
}
