using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wawa : MonoBehaviour
{
    public int count = 0; 
    // Start is called before the first frame update
    void Start()
    {
        water.Stop();
    }
    public ParticleSystem water;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("agarra");
            water.Play();
        }
        if(Input.GetButtonUp("Fire1"))
        {
            Debug.Log("mouse 0 up");
            water.Stop();
        }
        
    }
}
