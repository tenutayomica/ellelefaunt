using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public void Muerte()
    {
        Destroy(this.gameObject);
    }
}
