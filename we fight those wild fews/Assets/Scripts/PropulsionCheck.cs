using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropulsionCheck : MonoBehaviour
{
    public bool propulsing;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            propulsing = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            propulsing = true;
        }
    }
}
