using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIDaily : LocalManager<UIDaily>
{

    public List<DailySummary> dailySummaries;
    [SerializeField] private TextMeshProUGUI dayNumberText;
    [SerializeField] private TextMeshProUGUI summaryText; 

    [SerializeField] private GameObject rightArrow;
    [SerializeField] private GameObject leftArrow;
    private int numberDay;

    private void OnEnable() 
    {
        AudioManager.Instance.PlaySFX("Book");
        numberDay = dailySummaries.Count -  1;
        UpdateDaySummaryText();

    }

    public void UpdateDaySummaryText()
    {
        if(numberDay >= 1)
        {
            leftArrow.SetActive(true);
        }
        else
        {
            leftArrow.SetActive(false);
        }

        if(numberDay >= dailySummaries.Count-1)
        {
            rightArrow.SetActive(false);
        }
        else
        {
            rightArrow.SetActive(true);
        }


        dayNumberText.text = dailySummaries[numberDay].numberDay.ToString();
        summaryText.text = dailySummaries[numberDay].summary;
    }

    public void NextPage()
    {
        numberDay++;
        UpdateDaySummaryText();
    }

    public void LastPage()
    {
        numberDay--;
        UpdateDaySummaryText();
    }


}
