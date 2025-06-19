using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decreasespeed : MonoBehaviour
{
    bool inWater = false;
    public float speedyWater = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "Player")
        {
            inWater= true;
            other.GetComponentInParent<ThirdPersonMovement>().speed *= speedyWater;
        }

        }
        private void OnTriggerExit(Collider other)
        {
            inWater= false;
            other.GetComponentInParent<ThirdPersonMovement>().speed /= speedyWater;
        }
 
}
