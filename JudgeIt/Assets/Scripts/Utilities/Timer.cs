using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{


    public AudioSource audioTimer;
    public AudioClip tictac;
    public AudioClip endTimer;
    public TextMeshProUGUI textMeshProUGUI;

    private int timer;
    public void Init()
    {
        StopAllCoroutines();
        timer = 59;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while(timer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            if(timer > 9)
                textMeshProUGUI.text = "00:"+timer;
            else
                textMeshProUGUI.text = "00:0"+timer;
            timer--;
            if(timer == 5)
            {
                audioTimer.clip = tictac;
                audioTimer.Play();
            }
            if (timer  < 1)
            {
                audioTimer.clip = endTimer;
                audioTimer.Play();
            }
        }
        GameManager.Instance.EndTheGame();
    }
}
