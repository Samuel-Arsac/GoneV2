using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEntryDiary : MonoBehaviour
{
    [SerializeField] private List<DailySummary> newEntries;

    private void OnEnable()
    {
        for(int i = 0; i < newEntries.Count; i++)
        {
            UIDaily.Instance.dailySummaries.Add(newEntries[i]);
        }
        AudioManager.Instance.PlaySFX("Writing");
        UIManager.Instance.DisplayFeedback();
    }
}
