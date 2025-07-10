using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int life = 1;
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("entra");
  
        if (other.gameObject.tag == "wawa")
            life -= 1;
            if (life <= 0)
            {
    
              Destroy(this.gameObject);
              Debug.Log("muere");
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
