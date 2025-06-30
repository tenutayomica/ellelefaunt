using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wawa : MonoBehaviour
{ 
   public ParticleSystem water;
    public int watermeter;
    public int watermax = 100;
    public int watermin = 0;
    public bool inWater = false; 
    // Start is called before the first frame update
    void Start()
    {
        water.Stop();
    }
  
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("1") && inWater==true)
        {
            while(watermeter<watermax)
            {
                watermeter += 1; 
            }
            

        }
        



        if (Input.GetButtonDown("Fire1"))
        {
                while(watermeter>watermin)
                {
                   water.Play(); 
                }
                
                
                    
                Debug.Log("agarra");
            
        }
        if (Input.GetButtonUp("Fire1"))
        {
             Debug.Log("mouse 0 up");
                water.Stop();
            
        }
        
    }
}