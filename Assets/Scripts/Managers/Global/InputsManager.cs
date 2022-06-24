
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;

public class InputsManager :  LocalManager<InputsManager>
{
    [SerializeField] private InputSystemUIInputModule UIModule;
    public Controls controls;


    protected override void Awake()
    {
        base.Awake();
        controls = new Controls();

        controls.Keyboard.Back.performed += EscapeClick;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    public void ChangeLeftClickAction(CharacterInfo dialogueList)
    {
        UIModule.leftClick.action.Enable();
        UIModule.leftClick.action.performed += _ => ExamenManager.Instance.ClickMajorPoint(dialogueList);
    }

    public void RemoveLeftClickAction(CharacterInfo dialogueList)
    {
        UIModule.leftClick.action.started -= _ => ExamenManager.Instance.ClickMajorPoint(dialogueList);
        UIModule.leftClick.action.Disable();
    }

    public Vector2 ReadMousePostionValue()
    {
        return UIModule.point.action.ReadValue<Vector2>();
    }

    public Vector2 ReadMousePositionValueWorldSpace()

    {
        Vector2 mousePos = UIModule.point.action.ReadValue<Vector2>();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        return worldPos;
    }

    public void EscapeClick(InputAction.CallbackContext context)
    {
        UIManager.Instance.DisplayQuitConfirm();
    }

    public void EscapeLeave(InputAction.CallbackContext context)
    {
        UIManager.Instance.HideQuitConfirm();

    }

}
