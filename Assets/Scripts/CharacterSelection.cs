using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSelection : MonoBehaviour
{
    private int selectedCharacter;

    [Header("UI References")]
    [SerializeField] Image thumbnail;
    [SerializeField] TextMeshProUGUI characterName;
    

    [Header("Characters")]
    [SerializeField] List<characterSelectObject> characterList = new List<characterSelectObject>();

    [System.Serializable]
    public class characterSelectObject
    {
        public string name;
        public Sprite characterThumbnail;
    }

    private void Start()
    {
        UpdateCharacterSelectionUI();
    }

    public void CharacterSelectionLeftButtonOnClick()
    {
        if (0 > --selectedCharacter)
        {
            selectedCharacter = characterList.Count-1;
        }
            UpdateCharacterSelectionUI();
    }

    public void CharacterSelectionRightButtonOnClick()
    {
        if (characterList.Count-1 < ++selectedCharacter)
        {
            selectedCharacter = 0;
        }
        UpdateCharacterSelectionUI();
    }

    private void UpdateCharacterSelectionUI()
    {
        thumbnail.sprite = characterList[selectedCharacter].characterThumbnail;
        characterName.text = characterList[selectedCharacter].name;
    }
}
