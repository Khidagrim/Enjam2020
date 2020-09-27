using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AccusationHandler : MonoBehaviour
{
    public Button killBtn;
    public Button freeBtn;

    public void Init()
    {

        DebugColor.Blue("Init buttons acc");
        killBtn.onClick.AddListener(()=>{
            
            CharacterManager.Instance.JudgeCurrentCharacter(false);

        });

        freeBtn.onClick.AddListener(()=>{
            
            CharacterManager.Instance.JudgeCurrentCharacter(true);

        });
    }
}
