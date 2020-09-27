using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public GameObject characterHandler;
    public GameObject crimeHandlerPanel;

    public GameObject accusationHandler;

    public GameObject sliderJugementHandler;

    public GameObject EndGameMenu;

    public GameObject DefeatScreen;

    public TextMeshProUGUI timerTxt;
    private int timerInt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init()
    {
        timerInt = 59;
        crimeHandlerPanel.GetComponent<CrimeHandler>().Init();
        accusationHandler.GetComponent<AccusationHandler>().Init();
        characterHandler.GetComponent<CharacterHandler>().Init();
        sliderJugementHandler.GetComponent<SliderJugementHandler>().Init();
    }

    public void ShowHideDefeatScreen(bool show)
    {
        DefeatScreen.SetActive(show);
    }

    public void ShowHideEndGame(bool show)
    {
        if(show) EndGameMenu.GetComponent<EndGameMenuHandler>().Open();
        else EndGameMenu.GetComponent<EndGameMenuHandler>().Close();
    }
}
