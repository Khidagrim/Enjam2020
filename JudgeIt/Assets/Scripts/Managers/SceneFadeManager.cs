using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFadeManager : Singleton<SceneFadeManager>
{
    public float fadeTime = 1.0f;
    Image black;
    public delegate void OnFadeInDelegate();

    void Awake()
    {
        black = transform.GetChild(0).GetComponent<Image>();
    }

    private void OnEnable()
    {
        StartCoroutine(FadeToScene());
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(ChangeSceneCoroutine(sceneName));
    }

    #region Coroutines

    IEnumerator FadeToScene()
    {
        float alpha = 1;
        float fadeEndValue = 0;

        black.enabled = true;

        yield return new WaitUntil(() =>
        {
            alpha -= Time.deltaTime * fadeTime;

            Color c = black.color;
            black.color = new Color(c.r, c.g, c.b, alpha);

            return alpha <= fadeEndValue;
        });
    }

    IEnumerator FadeToBlack()
    {
        float alpha = 0;
        float fadeEndValue = 1;

        yield return new WaitUntil(() =>
        {
            alpha += Time.deltaTime * fadeTime;

            Color c = black.color;
            black.color = new Color(c.r, c.g, c.b, alpha);

            black.enabled = !(alpha >= fadeEndValue);

            return alpha >= fadeEndValue;
        });
    }

    IEnumerator ChangeSceneCoroutine(string sceneName)
    {
        yield return StartCoroutine(FadeToBlack());
        SceneManager.LoadScene(sceneName);
        StartCoroutine(FadeToScene());
    }

    /// <summary>
    /// Fade in, execute a method and then fade out
    /// </summary>
    /// <returns></returns>
    public IEnumerator FadeInOutExecute(OnFadeInDelegate function)
    {
        yield return FadeToBlack();
        function?.Invoke();
        yield return FadeToScene();
    }

    #endregion
}
