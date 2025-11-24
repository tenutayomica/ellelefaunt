using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialClues : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject tutorial2;
    bool flag1 = false;
    bool flag2 = false;

    private void OnTriggerStay(Collider other)
    {
        if (GameObject.Find("Contador").GetComponent<ContadorScript>().currentClues == 0 && GameObject.Find("GameManager").GetComponent<GameManager>().tutorial1needed && !flag1)
        {
            if (other.gameObject.tag == "Player") tutorial.SetActive(true);
        }
        else if (GameObject.Find("GameManager").GetComponent<GameManager>().tutorial1needed && !flag2)
        {
            tutorial.SetActive(false);
            StartCoroutine(FinalTutorial());
        }
        else tutorial.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        tutorial.SetActive(false);
    }
    IEnumerator FinalTutorial()
    {
        flag2 = true;
        tutorial2.SetActive(true);
        yield return new WaitForSeconds(4f);
        tutorial2.SetActive(false);
    }

    private void Update()
    {
        if (GameObject.Find("Contador").GetComponent<ContadorScript>().currentClues > 0) flag1 = true;
    }
}
