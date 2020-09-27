using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{

    /// <summary>
    /// Which set of character visuals we're using
    /// </summary>
    public CharacterVisuals characterVisualsSet;

    /// <summary>
    /// Reference to the current accusationHandler
    /// </summary>
    public CrimeHandler crimeHandler;

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

    public List<SpriteColorPair> GenerateNewCharacter()
    {
        // Safe check
        if (characterVisualsSet == null) return default(List<SpriteColorPair>);

        // Generate character's charges
        crimeHandler.GenerateNewCharges();

        // Generate character's visuals
        var character = characterVisualsSet.GenerateCharacter();
        return character;
    }
}
