using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
public class SelectionPanel : MonoBehaviour
{
    enum PanelState { Collapsed, Expanded };

    float openCloseSpeed;
    RectTransform panelRect;
    PanelState state = PanelState.Collapsed;
    Text buttonText;
    
    void Awake ()
    {
        panelRect = GetComponent<RectTransform>();
        buttonText = this.GetComponentInChildren<Button>().GetComponentInChildren<Text>();
    }
    
    public void ToggleSelectionPanel ()
    {
        if (state == PanelState.Collapsed)
        {
            panelRect.anchoredPosition = new Vector2(0, 0);
            buttonText.text = "<";
            state = PanelState.Expanded;
        }
        else // state == PanelState.Expanded
        {
            panelRect.anchoredPosition = new Vector2(-200, 0);
            buttonText.text = ">";
            state = PanelState.Collapsed;
        }
    }
}
*/