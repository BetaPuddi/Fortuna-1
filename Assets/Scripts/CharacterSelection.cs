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
    [SerializeField] Button startButton;
    

    [Header("Characters")]
    [SerializeField] List<CharacterInfo> characterList = new List<CharacterInfo>();
    int lockProgress;
    

    private void Start()
    {
        PersistentData.persistentData.loadCharacterLockState();
        lockProgress = PersistentData.persistentData.getCharactersLockProgress();
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
        characterName.text = characterList[selectedCharacter].characterName;
        PersistentData.persistentData.setCharacter(characterList[selectedCharacter]);
        startButton.interactable = (lockProgress & (1 << selectedCharacter)) != 0;//Determine if the character is unlocked or not
    }
}
