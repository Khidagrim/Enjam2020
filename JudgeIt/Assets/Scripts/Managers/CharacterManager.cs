using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{

    /// <summary>
    /// Which set of character visuals we're using
    /// </summary>
    public CharacterVisuals characterVisualsSet;

    public void Init()
    {
    }

    public void KillCurrentCharacter()
    {
        DebugColor.Orange("KILL character");
    }

    public void FreeCurrentCharacter()
    {
        DebugColor.Orange("FREE character");
    }

    public void GenerateNewCharacter(CharacterHandler charHandler)
    {
        if (characterVisualsSet == null) return;

        var character = characterVisualsSet.GenerateCharacter();
        charHandler.SetupCharacter(character);
    }
}
