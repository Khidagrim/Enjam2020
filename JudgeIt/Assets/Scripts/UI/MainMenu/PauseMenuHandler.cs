using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{

    Animation anim;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    public void Continue()
    {
        anim.Play("Hide");
        Time.timeScale = 1;
    }

    public void Pause()
    {
        anim.Play("Show");
    }
    public void Quit()
    {
        SceneFadeManager.Instance.ChangeScene("MainMenu");
    }

}
