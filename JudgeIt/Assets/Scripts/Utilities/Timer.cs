using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

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
        }
        GameManager.Instance.EndTheGame();
    }
}
