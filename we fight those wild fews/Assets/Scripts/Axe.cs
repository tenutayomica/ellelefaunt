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
            Collider[] checkClue = Physics.OverlapSphere(hitbox.position, axeRange);
            foreach (Collider other in checkClue)
            {
                if (other.gameObject.CompareTag("Clue"))
                {
                    ani.SetTrigger("Clue");
                    other.GetComponent<Outline>().seen = true;
                    other.GetComponent<Outline>().OutlineColor = Color.black;
                    StartCoroutine(ClueAnimWaittime());
                    return;
                }
            }
            StartCoroutine(AxeAttack());
            ani.SetTrigger("Axe");
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
    IEnumerator ClueAnimWaittime()
    {
        float speedHold = this.gameObject.GetComponent<ThirdPersonMovement>().speed;
        this.gameObject.GetComponent<ThirdPersonMovement>().speed = 0;
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<ThirdPersonMovement>().speed = speedHold;
    }
            
}
