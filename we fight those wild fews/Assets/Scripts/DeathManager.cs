using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public void Muerte()
    {
        this.gameObject.GetComponent<ThirdPersonMovement>().locked = true;
        this.gameObject.GetComponent<ThirdPersonMovement>().ani.SetTrigger("Death");
    }
}
