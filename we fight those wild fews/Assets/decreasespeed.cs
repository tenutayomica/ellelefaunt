using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decreasespeed : MonoBehaviour
{
    private bool isInWater=false;
    public float speedywater= 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         void OnTriggerEnter(collider other)
        {
            if(other.gameObject.tag== "wawa source"){
                isInWater= true;
                other.GetComponentInParent<ThirdPersonMovement>().speed *= speedywater;
            }

        }
        void OnTriggerExit(collider other){
            isInWater= false;
            other.GetComponentInParent<ThirdPersonMovement>().speed %= speedywater;
        }
    }
}
