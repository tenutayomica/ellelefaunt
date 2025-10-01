using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorScript : MonoBehaviour
{
    public List<GameObject> Fires;
    public List<GameObject> Victims;
    public List<GameObject> Clues;
    int currentFires;
    int firesTotal;
    int currentRescues;
    int rescuesTotal;
    int cluesTotal;
    int currentClues;
    public Text firesScore;
    public Text victimsScore;
    public Text cluesScore;
    public GameObject winPanel;

    void Start()
    {
        firesTotal = Fires.Count;
        rescuesTotal = Victims.Count;
        cluesTotal = Clues.Count;
    }

    void Update()
    {
        foreach (GameObject fire in Fires) if (fire == null) Fires.Remove(fire);
        currentFires = firesTotal - Fires.Count;
        foreach (GameObject rescue in Victims) if (rescue.GetComponent<VictimScript>().safe) Victims.Remove(rescue);
        currentRescues = rescuesTotal - Victims.Count;
        foreach (GameObject clue in Clues) if (clue.GetComponent<Outline>().seen) Clues.Remove(clue);
        currentClues = cluesTotal - Clues.Count;
        if (currentClues == cluesTotal && !winPanel.activeInHierarchy)
        {
            winPanel.SetActive(true);
            firesScore.text = currentFires.ToString() + "/" + firesTotal.ToString();
            victimsScore.text = currentRescues.ToString() + "/" + rescuesTotal.ToString();
            cluesScore.text = currentClues.ToString() + "/" + cluesTotal.ToString();
        }
    }
}
