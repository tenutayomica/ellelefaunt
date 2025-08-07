using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElefrutaScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().HP = other.gameObject.GetComponent<HealthManager>().maxHP;
            Destroy(this.gameObject);
        }
    }
}

