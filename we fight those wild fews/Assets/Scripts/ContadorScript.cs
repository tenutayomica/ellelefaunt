using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    void Start()
    {
        firesTotal = Fires.Count;
        rescuesTotal = Victims.Count;
        cluesTotal = Clues.Count;
    }

    void Update()
    {
        currentFires = firesTotal - Fires.Count;
        foreach (GameObject rescue in Victims) if (rescue.GetComponent<VictimScript>().safe) Victims.Remove(rescue);
        currentRescues = rescuesTotal - Victims.Count;
        foreach (GameObject clue in Clues) if (clue.GetComponent<Outline>().seen) Clues.Remove(clue);
        currentClues = cluesTotal - Clues.Count;
    }
}
