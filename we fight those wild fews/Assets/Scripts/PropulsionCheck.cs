using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropulsionCheck : MonoBehaviour
{
    public bool propulsing;
    wawa AguaScript;
    ThirdPersonMovement TPM;
    public float PropulsionForce;

    void Start()
    {
        AguaScript = GameObject.Find("wawa").GetComponent<wawa>();
        TPM = GetComponentInParent<ThirdPersonMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("other noticed");
        if (other.gameObject.tag == "Ground" && Input.GetKey(KeyCode.LeftShift) && !TPM.locked)
        {
            Debug.Log("propulsed");
            propulsing = true;
            TPM.verticalVelocity += PropulsionForce;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            propulsing = false;
        }
    }
}
