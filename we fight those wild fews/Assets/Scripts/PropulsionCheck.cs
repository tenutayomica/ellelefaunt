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

    void Update()
    {
        if (Physics.Raycast(this.gameObject.transform.position, Vector3.down, 3f, TPM.groundLayer))
        {
            if (Input.GetKey(KeyCode.LeftShift) && TPM.locked == false)
            {
                Debug.Log("propulsed");
                propulsing = true;
                TPM.verticalVelocity += PropulsionForce;
            }
            else 
            {
                if (propulsing) TPM.verticalVelocity = 0;
                propulsing = false;
            }
        }

    }
}
