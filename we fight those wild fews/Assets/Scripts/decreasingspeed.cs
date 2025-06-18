using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decreasingspeed : MonoBehaviour

{
    private bool isInWater= false;
    public float speedywater= 0.5f;
    public float currentspeed;


    // Start is called before the first frame update
    void Start()
    {
        void OnTriggerEnter(collider other)
        {
            if(other.gameObject.tag== "wawa source"){
                isInWater= true; 
                currentspeed= 
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
