using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelSelection : MonoBehaviour
{
    private int selectedTrack;

    [Header("UI References")]
    [SerializeField] Image thumbnail;
    [SerializeField] TextMeshProUGUI levelName;
    

    [Header("Tracks")]
    [SerializeField] List<LevelSelectObject> trackList = new List<LevelSelectObject>();

    [System.Serializable]
    public class LevelSelectObject
    {
        public string name;
        public Sprite levelThumbnail;
    }

    private void Start()
    {
        UpdateTrackSelectionUI();
    }

    private void TrackSelectionLeftButtonOnClick()
    {
        selectedTrack--;
        UpdateTrackSelectionUI();
    }

    private void TrackSelectionRightButtonOnClick()
    {
        selectedTrack++;
        UpdateTrackSelectionUI();
    }

    private void UpdateTrackSelectionUI()
    {
        thumbnail.sprite = trackList[selectedTrack].levelThumbnail;
        levelName.text = trackList[selectedTrack].name;
    }
}
