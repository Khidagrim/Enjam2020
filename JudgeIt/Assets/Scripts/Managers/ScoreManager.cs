using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    /// <summary>
    /// The audience score, on top
    /// </summary>


    public float curAudienceAtStart = 50;

    private float m_currentAudience;

    public float CurrentAudience{
        get{
            return m_currentAudience;
        }
        set{
            m_currentAudience = value;
            UIManager.Instance.sliderJugementHandler.GetComponent<SliderJugementHandler>().ChangeSliderValue(value);

            if(m_currentAudience <= 0 )
            {
                GameManager.Instance.Defeat();
            }
        }
    }


    public float maxAudience = 100;

    /// <summary>
    /// The "morality" score, to see if the player is a good or bad judge
    /// </summary>
    [HideInInspector] public float nb_errors = 0;
    public float errorThreshold = 10f;

    public float scoreIncreaseKill = 10;
    public float scoreIncreaseFree = 5;


    public float timerBeforeDecrease = 5;
    private float currentTimer;

    public float scoreDecreaseRate = 1;


    public void Init()
    {
        m_currentAudience = curAudienceAtStart;
        ResetTimer();
    }

    void Update()
    {
        if(GameManager.Instance.gameHasStarted)
        {
            currentTimer -= Time.deltaTime;
            if(currentTimer < 0)
            {
                ScoreManager.Instance.CurrentAudience -= Time.deltaTime * scoreDecreaseRate;
            }
        }
        
    }

    public void ResetTimer()
    {
        currentTimer = timerBeforeDecrease;
    }

}
