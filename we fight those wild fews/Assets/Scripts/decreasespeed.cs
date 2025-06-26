using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decreasespeed : MonoBehaviour
{
    public float speedyWater = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "Player")
        {
            other.GetComponentInParent<wawa>().inWater= true;
            other.GetComponentInParent<ThirdPersonMovement>().speed *= speedyWater;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag== "Player")
        {
             other.GetComponentInParent<wawa>().inWater= true;
            other.GetComponentInParent<ThirdPersonMovement>().speed /= speedyWater;
        }
    }
 
}z
