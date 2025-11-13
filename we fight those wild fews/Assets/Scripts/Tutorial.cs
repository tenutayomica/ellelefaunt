using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] texts;
    GameManager gm;
    bool[] flags = {false, false, false, false};

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gm.tutorial1needed)
        {
            texts[0].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("wawa").GetComponent<wawa>().watermeter > 0)
        {
            texts[1].SetActive(true);
            texts[0].SetActive(false);
            flags[0] = true;
        }
        if (flags[0] = true & GameObject.Find("Contador").GetComponent<ContadorScript>().firesTotal > GameObject.Find("Contador").GetComponent<ContadorScript>().currentFires)
        {
            texts[1].SetActive(false);
            flags[1] = true;
        }
    }
}
