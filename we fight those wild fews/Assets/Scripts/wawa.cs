using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wawa : MonoBehaviour
{ 
   public ParticleSystem water;
    public int watermeter;
    public int watermax = 200;
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
        if (Input.GetMouseButton(1) && inWater==true)
        {
            if(watermeter<watermax)
            {
                watermeter += 2; 
                Debug.Log(watermeter);
            }
            

        }
     
       



        if (Input.GetButton("Fire1"))
        {
                if(watermeter>watermin)
                {
                   water.Play(); 
                   watermeter -= 1; 
                   
                }
                else{
                    water.Stop();
                }
                
                    
                Debug.Log("agarra");
            
        }
        if (Input.GetButtonUp("Fire1"))
        {
             
                water.Stop();
            
        }
        
    }
}