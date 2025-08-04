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
    public Animator ani;
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
            ani.SetBool("Sucking", true);
        }
        else
        {
            ani.SetBool("Sucking", false);
        }
     
       



        if (Input.GetButton("Fire1"))
        {
            ani.SetBool("Shooting", true);
                if(watermeter>watermin)
                {
                   water.Play(); 
                   watermeter -= 1; 
                   
                }
                else{
                    water.Stop();
                }
                
                    
                
            
        }
        if (Input.GetButtonUp("Fire1"))
        {
            ani.SetBool("Shooting", false);
            water.Stop();
        }
        
    }
}