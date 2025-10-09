using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public Transform hitbox;
    public float axeRange;
    public LayerMask breakLayer;
    public Animator ani;
    bool axing = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !axing)
        {
            GetComponentInChildren<wawa>().dryActivity = true;
            axing = true;
            Collider[] checkClue = Physics.OverlapSphere(hitbox.position, axeRange);
            foreach (Collider other in checkClue)
            {
                if (other.gameObject.CompareTag("Clue"))
                {
                    if (GameObject.Find("Contador").GetComponent<ContadorScript>().Clues.Count != 1) ani.SetTrigger("Clue");
                    other.GetComponent<Outline>().seen = true;
                    other.GetComponent<Outline>().OutlineColor = Color.black;
                    if (GameObject.Find("Contador").GetComponent<ContadorScript>().Clues.Count != 1) StartCoroutine(ClueAnimWaittime());
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
        axing = false;
    }
    IEnumerator ClueAnimWaittime()
    {
        this.gameObject.GetComponent<ThirdPersonMovement>().locked = true;
        yield return new WaitForSeconds(3.5f);
        this.gameObject.GetComponent<ThirdPersonMovement>().locked = false;
        axing = false;
    }
            
}
