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
    [SerializeField] List<TrackInfo> trackList = new List<TrackInfo>();

    

    private void Start()
    {
        UpdateTrackSelectionUI();
    }

    public void TrackSelectionLeftButtonOnClick()
    {
        if (0 > --selectedTrack)
        {
            selectedTrack = trackList.Count - 1;
        }
        UpdateTrackSelectionUI();
    }

    public void TrackSelectionRightButtonOnClick()
    {
        if (trackList.Count - 1 < ++selectedTrack)
        {
            selectedTrack = 0;
        }
        UpdateTrackSelectionUI();
    }

    private void UpdateTrackSelectionUI()
    {
        thumbnail.sprite = trackList[selectedTrack].trackThumbnail;
        levelName.text = trackList[selectedTrack].trackName;
        PersistentData.persistentData.setTrack(trackList[selectedTrack]);
    }
}
