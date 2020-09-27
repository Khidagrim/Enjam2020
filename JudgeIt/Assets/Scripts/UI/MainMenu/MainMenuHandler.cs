using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public void PlayGame()
    {
        SceneFadeManager.Instance.ChangeScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
