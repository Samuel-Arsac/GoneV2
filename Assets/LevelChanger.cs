using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : LocalManager<LevelChanger>
{
    [SerializeField] private Animator fadeAnimator;
    private string sceneToLoad;
    public void OnFadeOutComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void OnFadeInBegins()
    {
        UIManager.Instance.HideIcons();
        UIManager.Instance.DisableInteractionEnvironnment();
    }

    public void OnFadeInComplete()
    {
        UIManager.Instance.DisplayIcons();
        //UIManager.Instance.EnableInteractionEnvironnment();
    }

    public void FadeToLevel(string sceneName)
    {
        UIManager.Instance.DisableInteractionEnvironnment();
        UIManager.Instance.HideIcons();
        fadeAnimator.SetTrigger("FadeOut");
        sceneToLoad = sceneName;
    }
}
