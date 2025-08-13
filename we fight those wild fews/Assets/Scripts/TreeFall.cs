using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
    public Animator ani;
    public GameObject trigger;

    void Update()
    {
        if (trigger == null) ani.SetBool("Broken", true);
    }
}
