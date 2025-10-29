using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PropulsionCheck : MonoBehaviour
{
    public bool propulsing;
    wawa AguaScript;
    ThirdPersonMovement TPM;
    public float PropulsionForce;
    public ParticleSystem wawa;

    void Start()
    {
        AguaScript = GameObject.Find("wawa").GetComponent<wawa>();
        TPM = GetComponentInParent<ThirdPersonMovement>();
    }

    void Update()
    {
        if (Physics.Raycast(this.gameObject.transform.position, Vector3.down, 5f, TPM.groundLayer))
        {
            if (Input.GetKey(KeyCode.LeftShift) && TPM.locked == false && AguaScript.watermeter > 0)
            {
                Debug.Log("propulsed");
                AguaScript.dryActivity = true;
                propulsing = true;
                TPM.verticalVelocity += PropulsionForce;
                TPM.ani.SetBool("Propulsing", true);
                AguaScript.watermeter -= 2;
                wawa.Play();
            }
            else
            {
                if (propulsing)
                {
                    TPM.verticalVelocity = 0;
                    AguaScript.dryActivity = false;
                }
                propulsing = false;
                TPM.ani.SetBool("Propulsing", false);
                wawa.Stop();
            }
        }
        else if (Physics.Raycast(this.gameObject.transform.position, Vector3.down, 5.5f, TPM.groundLayer))
        {
            if (Input.GetKey(KeyCode.LeftShift) && TPM.locked == false && AguaScript.watermeter > 0)
            {
                Debug.Log("topped");
                propulsing = true;
                AguaScript.dryActivity = true;
                TPM.verticalVelocity = TPM.verticalVelocity / 2;
                TPM.ani.SetBool("Propulsing", true);
                AguaScript.watermeter -= 1;
                wawa.Play();
            }
            else
            {
                if (propulsing)
                {
                    TPM.verticalVelocity = 0;
                    AguaScript.dryActivity = false;
                }
                propulsing = false;
                TPM.ani.SetBool("Propulsing", false);
                wawa.Stop();
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift) && !TPM.locked && AguaScript.watermeter > 0)
        {
            TPM.ani.SetBool("Propulsing", true);
            propulsing = true;
            AguaScript.dryActivity = true;
            AguaScript.watermeter -= 1;
            wawa.Play();
        }
        else
        {
            if (propulsing) AguaScript.dryActivity = false;
            TPM.ani.SetBool("Propulsing", false);
            wawa.Stop();
        }

    }
}
