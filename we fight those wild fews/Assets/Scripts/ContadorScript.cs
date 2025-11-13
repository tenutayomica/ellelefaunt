using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorScript : MonoBehaviour
{
    public List<GameObject> Fires;
    public List<GameObject> Victims;
    public List<GameObject> Clues;
    public int currentFires;
    public int firesTotal;
    int currentRescues;
    int rescuesTotal;
    int cluesTotal;
    int currentClues;
    public Text firesScore;
    public Text victimsScore;
    public Text cluesScore;
    public GameObject winPanel;
    public Animator ani;
    bool win = false;

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
        if (currentClues == cluesTotal && !winPanel.activeInHierarchy && !win)
        {
            win = true;
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        ani.SetTrigger("Win");
        GameObject.Find("Trompita").GetComponent<ThirdPersonMovement>().locked = true;
        yield return new WaitForSeconds(3.5f);
        winPanel.SetActive(true);
        firesScore.text = currentFires.ToString() + "/" + firesTotal.ToString();
        victimsScore.text = currentRescues.ToString() + "/" + rescuesTotal.ToString();
        cluesScore.text = currentClues.ToString() + "/" + cluesTotal.ToString();
    }
}
