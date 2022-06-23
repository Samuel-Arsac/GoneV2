using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIProfiles : MonoBehaviour
{
    [SerializeField] private List<Profiles> charactersProfiles;
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI characterInformations;
    [SerializeField] private Image currentCharacterImage;

    [SerializeField] private GameObject globalSection;
    [SerializeField] private GameObject charactersSection;

    [SerializeField] private GameObject rightArrow;
    [SerializeField] private GameObject leftArrow;
    private int currentCharacter;

    private void OnEnable()
    {
        if (UIManager.Instance.GetIntialisation())
        {
            AudioManager.Instance.PlaySFX("Book");
        }
    }

    public void UpdateProfilesText()
    {
        if(currentCharacter >= 1)
        {
            leftArrow.SetActive(true);
        }
        else
        {
            leftArrow.SetActive(false);
        }

        if(currentCharacter >= charactersProfiles.Count-1)
        {
            rightArrow.SetActive(false);
        }
        else
        {
            rightArrow.SetActive(true);
        }

        characterNameText.text = charactersProfiles[currentCharacter].characterName;
        characterInformations.text = charactersProfiles[currentCharacter].characterDescriptions;
        currentCharacterImage.sprite = charactersProfiles[currentCharacter].characterSprite;
        currentCharacterImage.preserveAspect = true;
    }

    private void OnDisable()
    {
        globalSection.SetActive(true);
        charactersSection.SetActive(false);
    }

    public void NextProfile()
    {
        currentCharacter++;
        UpdateProfilesText();
    }

    public void LastProfile()
    {
        currentCharacter--;
        UpdateProfilesText();
    }

    public void DisplaySpecifiques(int characterNumber)
    {
        currentCharacter = characterNumber;
        globalSection.SetActive(false);
        charactersSection.SetActive(true);

        UpdateProfilesText();
    }

    public void DisplayGloabalSection()
    {
        globalSection.SetActive(true);
        charactersSection.SetActive(false);
    }
}
