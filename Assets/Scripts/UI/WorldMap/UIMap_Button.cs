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

    public void OnClick()
    {
        OutlineZoneHide();
        UIWorldMap.Instance.currentZone = linkedZone;
        
    }
}
