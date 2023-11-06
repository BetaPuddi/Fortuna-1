using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPanelControllerSelector : MonoBehaviour
{
    [SerializeField] GameObject nextPanel;
    [SerializeField] EventSystem eventSystem;

    public void SelectButton()
    {
        foreach (Transform ui in nextPanel.transform)
        {
            if (ui.GetComponent<Button>() != null)
            {
                eventSystem.SetSelectedGameObject(ui.gameObject);
                break;
            }
        }
    }
}
