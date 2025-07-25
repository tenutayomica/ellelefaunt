using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public Transform hitbox;
    public float axeRange;
    public LayerMask breakLayer;
    public Animator ani;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ani.SetTrigger("Axe");
            StartCoroutine(AxeAttack());
        }
    }
    IEnumerator AxeAttack()
    {
        yield return new WaitForSeconds(0.2f);
        Collider[] hitBreak = Physics.OverlapSphere(hitbox.position, axeRange, breakLayer);
        foreach (Collider other in hitBreak)
        {
            Destroy(other.gameObject);
        }
    }
}
