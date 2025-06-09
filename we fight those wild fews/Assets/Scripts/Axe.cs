using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public Transform hitbox;
    public float axeRange;
    public LayerMask breakLayer;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider[] hitBreak = Physics.OverlapSphere(hitbox.position, axeRange, breakLayer);
            foreach (Collider other in hitBreak)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
