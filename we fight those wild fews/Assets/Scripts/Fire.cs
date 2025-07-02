using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "wawa")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<HealthManager>().iframes == false)
        {
            other.gameObject.GetComponent<HealthManager>().HP -= 1;
        }
    }
}
