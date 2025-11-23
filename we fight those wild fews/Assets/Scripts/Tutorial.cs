using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] texts;
    GameManager gm;
    public bool[] flags;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gm.tutorial1needed)
        {
            texts[0].SetActive(true);
        }
        flags[0] = false;
        flags[1] = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("wawa").GetComponent<wawa>().watermeter > 0 && flags[0] != true)
        {
            texts[1].SetActive(true);
            texts[0].SetActive(false);
            flags[0] = true;
        }
        if (flags[0] && !flags[1] && GameObject.Find("Contador").GetComponent<ContadorScript>().currentFires > 0)
        {
            Debug.Log("nana");
            texts[1].SetActive(false);
            flags[1] = true;
        }
    }
}
