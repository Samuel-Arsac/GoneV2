using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class ScenesManager : LocalManager<ScenesManager>
{
    [SerializeField] private CharacterInfo cantTravelDialogue;

    /*protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }*/

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
        Debug.Log("Leaving game");
    }

    public void LoadNewZone(string sceneToLoad)
    {
        if(UIWorldMap.Instance.canTravel)
        {
            LevelChanger.Instance.FadeToLevel(sceneToLoad);

        }
        else
        {
            UIWorldMap.Instance.DisplayUIWordlMap();
            DialogueHandler.Instance.startDialogue(cantTravelDialogue, true);
        }
        
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIManager.Instance.worldCanvasGameObject = GameObject.FindGameObjectWithTag("World Canvas");
        UIManager.Instance.presentInspeciton = GameObject.FindGameObjectWithTag("Present");
        UIManager.Instance.pastInspection = GameObject.FindGameObjectWithTag("Past");

        UIManager.Instance.SetCanvasInteractable();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Gare");
    }
}
