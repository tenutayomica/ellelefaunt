using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wawa")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
