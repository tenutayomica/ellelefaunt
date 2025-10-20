using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class othernamesrc : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent < HealthManager >().HP -= 1;
            Destroy(this.gameObject);
            Debug.Log("destroyed by trompita");
        }
        if (other.gameObject.tag == "Extermination cube")
        {
            if (Input.GetButton("Fire1"))
            {
                if (GameObject.Find("wawa").GetComponent<wawa>().watermeter > 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    } 

}
