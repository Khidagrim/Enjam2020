using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    

    public void Init()
    {
        // recuperer les scriptable objects

    }

    public void KillCurrentCharacter()
    {
        DebugColor.Orange("KILL character");
    }

    public void FreeCurrentCharacter()
    {
        DebugColor.Orange("FREE character");
    }
}
