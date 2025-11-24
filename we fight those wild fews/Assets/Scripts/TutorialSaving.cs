using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSaving : MonoBehaviour
{
    public GameObject tutorial;
    bool flag = false;

    private void OnTriggerStay(Collider other)
    {
        if (GameObject.Find("Contador").GetComponent<ContadorScript>().currentRescues == 0 && GameObject.Find("GameManager").GetComponent<GameManager>().tutorial1needed && !flag)
        {
            if (other.gameObject.tag == "Player")tutorial.SetActive(true);
        }
        else tutorial.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        tutorial.SetActive(false);
    }
    private void Update()
    {
        if (GameObject.Find("Contador").GetComponent<ContadorScript>().currentRescues > 0) flag = true;
    }
}
