using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wawa : MonoBehaviour
{ 
   public ParticleSystem water;
    public float watermeter;
    public float watermax = 100f;
    public float watermin = 0f;
    bool inwater = false; 
    // Start is called before the first frame update
    void Start()
    {
        water.Stop();
    }
  
    
    // Update is called once per frame
    void Update()
    {
        //if(other.gameObject.tag== "water") 
        if (Input.GetButtonDown("Fire1"))
        {
            if (watermeter > 0)
            {
                water.Play();
                    
                Debug.Log("agarra");
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (watermeter == 0)
            {

                
    Debug.Log("mouse 0 up");
                water.Stop();
            }
        }
        
    }
}
