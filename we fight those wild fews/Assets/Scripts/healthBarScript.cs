using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarScript : MonoBehaviour
{
    public Slider slider;
    public void SetWater(int water)
    {
        slider.value = water; 
    }
    
}
