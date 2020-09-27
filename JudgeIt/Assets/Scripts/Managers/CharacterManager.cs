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
    [HideInInspector] public CrimeHandler crimeHandler;

    public List<string> FreeKillMemoryList;

    public int valueBeforeAudienceGetsAngry;

    public void Init()
    {
        FreeKillMemoryList = new List<string>();
    }

    public void JudgeCurrentCharacter(bool isFreed)
    {
        DebugColor.Orange("KILL/Free character");
        // on recup le score general
        int score = 0;
        foreach(ChargeData chg in crimeHandler.curCharges)
        {
            score += chg.points;
        }

        Debug.Log("Score = "+score);
        float scoreModificator = 0f;

        if(!isFreed)// si il est condamné
        {
            FreeKillMemoryList.Add("kill");

            scoreModificator = GetAllLastPlayerChoices("kill") * ScoreManager.Instance.scoreIncreaseKill / 3;
            DebugColor.Purple("Score Modificator : "+scoreModificator); 

            if(score < 0)// et qu il ne le devait pas
                ScoreManager.Instance.nb_errors += 1;

            ScoreManager.Instance.CurrentAudience += ( ScoreManager.Instance.scoreIncreaseKill - scoreModificator);  
            
            //On déplace le personnage vers la droite + feedback relax
        }
        else // si il est relaxé
        {
            FreeKillMemoryList.Add("free");

            scoreModificator = GetAllLastPlayerChoices("free") * ScoreManager.Instance.scoreIncreaseFree / 3;
            DebugColor.Purple("Score Modificator : "+scoreModificator); 

            if(score > 0)// le joueur n'as pas jugé correctement;
                ScoreManager.Instance.nb_errors += 1;

            ScoreManager.Instance.CurrentAudience += ( ScoreManager.Instance.scoreIncreaseFree - scoreModificator);    
            //on déplace le personnage vers la gauche + feedback condamner
        }

        //reset le timer de score decrease
        ScoreManager.Instance.ResetTimer();

        if(FreeKillMemoryList.Count > valueBeforeAudienceGetsAngry)
            FreeKillMemoryList.Remove(FreeKillMemoryList[0]);
        
        UIManager.Instance.crimeHandlerPanel.GetComponent<CrimeHandler>().curCharges.Clear();

        UIManager.Instance.characterHandler.GetComponent<CharacterHandler>().SetupCharacter(GenerateNewCharacter());
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

    int GetAllLastPlayerChoices(string thisChoice)
    {
        int r = 0;
        for(int i = FreeKillMemoryList.Count - 1; i > 0; i--)
        {
            if(FreeKillMemoryList[i] == thisChoice)
                r++;
        }
        return r;
    }
}
