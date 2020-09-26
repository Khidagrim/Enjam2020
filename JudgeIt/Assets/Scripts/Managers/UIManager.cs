using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject characterHandler;
    public GameObject crimeHandlerPanel;

    public GameObject accusationHandler;

    public GameObject sliderJugementHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init()
    {
        characterHandler.GetComponent<CharacterHandler>().Init();
        crimeHandlerPanel.GetComponent<CrimeHandler>().Init();
        accusationHandler.GetComponent<AccusationHandler>().Init();
        sliderJugementHandler.GetComponent<SliderJugementHandler>().Init();
    }

}
