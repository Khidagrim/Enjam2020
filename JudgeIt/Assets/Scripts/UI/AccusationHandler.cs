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
            
            CharacterManager.Instance.KillCurrentCharacter();

        });

        freeBtn.onClick.AddListener(()=>{
            
            CharacterManager.Instance.FreeCurrentCharacter();

        });
    }
}
