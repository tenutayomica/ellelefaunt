using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHP = 3;
    public int HP = 3;
    private int pastHP = 3;
    public bool iframes = false;
    public float IFlen;
    public GameObject[] hpd;
    bool dead = false;

    void Update()
    {
        if (HP < pastHP) if (HP != pastHP -1) HP = pastHP -1;
        if (HP <= 0 && !dead)
        {
            dead = true;
            GetComponentInParent<DeathManager>().Muerte();
            GetComponentInChildren<wawa>().dryActivity = true; 
        }
        if (HP < pastHP && HP > 0) StartCoroutine(Iframes());
        pastHP = HP;
        if (HP <= 0)
        {
            hpd[0].SetActive(false);
            hpd[1].SetActive(false);
            hpd[2].SetActive(false);
        }
        if (HP == 1)
        {
            hpd[0].SetActive(true);
            hpd[1].SetActive(false);
            hpd[2].SetActive(false);
        }
        if (HP == 2)
        {
            hpd[0].SetActive(true);
            hpd[1].SetActive(true);
            hpd[2].SetActive(false);
        }
        if (HP == 3)
        {
            hpd[0].SetActive(true);
            hpd[1].SetActive(true);
            hpd[2].SetActive(true);
        }
    }

    IEnumerator Iframes()
    {
        this.gameObject.GetComponent<ThirdPersonMovement>().ani.SetTrigger("Hurt");
        iframes = true;
        this.gameObject.GetComponent<ThirdPersonMovement>().locked = true;
        yield return new WaitForSeconds(1.5f);
        this.gameObject.GetComponent<ThirdPersonMovement>().locked = false;
        yield return new WaitForSeconds(IFlen);
        iframes = false;
    }
}
