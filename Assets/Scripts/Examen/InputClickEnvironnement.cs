using UnityEngine;
using UnityEngine.EventSystems;

public class InputClickEnvironnement : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData ctx)
    {
        Debug.Log("Oui");
    }

}