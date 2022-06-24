using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamenTransition : MonoBehaviour
{
    [SerializeField] private bool enviro;
    private void Start()
    {
        UIManager.Instance.DisableInteractionEnvironnment();
        UIManager.Instance.HideIcons();
    }

    public void StartExamen()
    {
        if(enviro)
        {
            Debug.Log("enviro");
            CursorsManager.instance.HideCursor();
            UIManager.Instance.CallFade();
            UIManager.Instance.EnableEnvironementExamen();
            
        }
        else
        {
            Debug.Log("pas enviro");
            UIInventory.Instance.HideTransition();
        }
    }
}
