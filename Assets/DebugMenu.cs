using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : ProjectManager<DebugMenu>
{
    [SerializeField] private CanvasGroup canvasGroup;

    public void DisplayDebugMenu()
    {
        InputsManager.Instance.controls.Keyboard.EnableDebugMenu.performed -= InputsManager.Instance.DebugMenuDisplay;
        InputsManager.Instance.controls.Keyboard.EnableDebugMenu.performed += InputsManager.Instance.DebugMenuHide;
        canvasGroup.alpha = 1;
    }

    public void HideDebugMenu()
    {
        InputsManager.Instance.controls.Keyboard.EnableDebugMenu.performed += InputsManager.Instance.DebugMenuDisplay;
        InputsManager.Instance.controls.Keyboard.EnableDebugMenu.performed -= InputsManager.Instance.DebugMenuHide;
        canvasGroup.alpha = 0;
    }

}
