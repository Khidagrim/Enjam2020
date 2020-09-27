using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderJugementHandler : MonoBehaviour
{

    public Slider slider;

    public void Init()
    {
        slider.maxValue = ScoreManager.Instance.maxAudience;
        slider.value = ScoreManager.Instance.CurrentAudience;
    }

    public void ChangeSliderValue(float val)
    {
        slider.value = val;
    }
}
