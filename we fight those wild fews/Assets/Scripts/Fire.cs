using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int life = 1;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<HealthManager>().iframes == false)
        {
            other.gameObject.GetComponent<HealthManager>().HP -= 1;
        }
        if (other.gameObject.tag == "Extermination cube")
        {
            Debug.Log("entra");
            if (Input.GetButton("Fire1"))
            {
                if( GameObject.Find("wawa").GetComponent<wawa>().watermeter > 0)
                {
                   life -= 1;
                   Debug.Log("low");
                }
                
            }

        }
        if (life <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("muere");
            
        }
    }
}
