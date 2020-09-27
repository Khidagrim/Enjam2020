using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameMenuHandler : MonoBehaviour
{
    public TextMeshProUGUI feedbackPlayerGame; // good or bad judge
    
    public Button quitter;
    public Button rejouer;

    private bool m_isInit;

    public void Open()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        if(!m_isInit) Init();

        if(ScoreManager.Instance.nb_errors < ScoreManager.Instance.errorThreshold)
            feedbackPlayerGame.text = "Vous etes un BON juge";
        else
            feedbackPlayerGame.text = "Vous etes un MAUVAIS juge";

    }

    public void Close()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    
    public void Init()
    {   
        rejouer.onClick.AddListener(()=>{
            GameManager.Instance.Init();
            Close();
        });

        quitter.onClick.AddListener(()=>
        {
            GameManager.Instance.LoadMenu();
        });
    }
}
