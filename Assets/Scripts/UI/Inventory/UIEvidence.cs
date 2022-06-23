using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIEvidence : MonoBehaviour
{
    [SerializeField] private List<Transform> slotsList;
    [SerializeField] private RectTransform slotsParents;
    [SerializeField] private VerticalLayoutGroup grid;
    private EventTrigger trigger;

    private void Awake()
    {
        grid.CalculateLayoutInputHorizontal();
        grid.SetLayoutHorizontal();
        grid.CalculateLayoutInputVertical();
        grid.SetLayoutVertical();
    }

    private void OnEnable() 
    {
        List<Item> items = null;
        items = ItemsManager.Instance.GetExaminedObjects();

        for(int i = 0; i < items.Count; i++)
        {
            items[i].transform.position = slotsList[i].position;
            items[i].transform.localScale = slotsList[i].localScale;
            items[i].gameObject.SetActive(true);
            Draggable drag = items[i].gameObject.AddComponent<Draggable>();
            drag.itemCanvasGroup = items[i].GetComponent<CanvasGroup>();
        }
    }

    private void OnDisable()
    {
        List<Item> items = null;
        items = ItemsManager.Instance.GetExaminedObjects();
        

        for(int i = 0; i < items.Count; i++)
        {
            items[i].transform.position = Vector3.zero;
            items[i].gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
            if(Application.isPlaying)
            {
                Destroy(items[i].gameObject.GetComponent<Draggable>());
            }
            else
            {
                DestroyImmediate(items[i].gameObject.GetComponent<Draggable>());
            }
            
            items[i].gameObject.SetActive(false);
            
        }
    }

}
