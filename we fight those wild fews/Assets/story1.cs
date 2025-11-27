using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class story1 : MonoBehaviour
{
    public GameObject storyPanel;
    public void imgageAppear()
    {
 
        if (storyPanel != null)
        {
            
            bool currentState = storyPanel.gameObject.activeSelf;

            
            storyPanel.gameObject.SetActive(!currentState);
        }
    }
}
