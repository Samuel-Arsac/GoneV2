using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Sections")]
    [SerializeField] private GameObject mainSection;
    [SerializeField] private GameObject optionsSection;
    [SerializeField] private GameObject creditsSection;
    [SerializeField] private CanvasGroup mainMenuCanvasGroup;
    [SerializeField] private string sceneToLoad = "Introduction";

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void DisplayCredits()
    {
        mainSection.SetActive(false);
        creditsSection.SetActive(true);
    }

    public void HideCredits()
    {
        mainSection.SetActive(true);
        creditsSection.SetActive(false);
    }

    public void DisplayOptionsSection()
    {
        optionsSection.SetActive(true);
        mainMenuCanvasGroup.interactable = false;
        mainMenuCanvasGroup.blocksRaycasts = false;
    }

    public void HideOptionsSection()
    {
        optionsSection.SetActive(false);
        mainMenuCanvasGroup.interactable = true;
        mainMenuCanvasGroup.blocksRaycasts = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
