using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trompica : MonoBehaviour
{
    GameObject[] wawas;
    public GameObject wawaw;
    private void Update()
    {
        wawaw.GetComponent<wawa>().count += 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wawa source")
        {
        }
    }
}
