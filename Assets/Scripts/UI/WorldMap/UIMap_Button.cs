using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMap_Button : MonoBehaviour
{
    private GameObject outlineZone;
    [SerializeField] private UIWorldMap.zones linkedZone;

    private void Awake()
    {
        outlineZone = transform.GetChild(0).gameObject;
    }

    public void OutlineZoneDisplay()
    {
        outlineZone.SetActive(true);
    }

    public void OutlineZoneHide()
    {
        outlineZone.SetActive(false);
    }

    public void OnClick(string sceneToLoad)
    {
        
        if (UIWorldMap.Instance.cantGoToRailway && linkedZone == UIWorldMap.zones.Gare)
        {
            Debug.Log("Oui");
            DialogueHandler.Instance.StartDialogueCantTravelRailway();
            UIWorldMap.Instance.DisplayUIWordlMap();
            UIManager.Instance.DisableInteractionEnvironnment();
        }

        else if(UIWorldMap.Instance.cantGoToHostel && (linkedZone == UIWorldMap.zones.Hôtel || linkedZone == UIWorldMap.zones.Gare))
        {
            Debug.Log("Oui2");
            DialogueHandler.Instance.StartDialogueCantTravelAway();
            UIWorldMap.Instance.DisplayUIWordlMap();
            UIManager.Instance.DisableInteractionEnvironnment();
        }

        else if(UIWorldMap.Instance.canTravel)
        {
            Debug.Log("Oui3");
            UIWorldMap.Instance.currentZone = linkedZone;
            LevelChanger.Instance.FadeToLevel(sceneToLoad);
            UIManager.Instance.DisableInteractionEnvironnment();

        }
        else
        {
            Debug.Log("Oui4");
            UIWorldMap.Instance.DisplayUIWordlMap();
            DialogueHandler.Instance.StartDialogueCantTravelWatch();

            UIManager.Instance.DisableInteractionEnvironnment();
        }

        //UIWorldMap.Instance.DisplayUIWordlMap();
        OutlineZoneHide();




    }
}
