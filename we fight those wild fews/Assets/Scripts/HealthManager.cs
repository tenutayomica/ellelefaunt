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
    public Text[] hpd;

    void Update()
    {
        if (HP <= 0) GetComponentInParent < DeathManager >().Muerte();
        if (HP < pastHP) StartCoroutine(Iframes());
        pastHP = HP;
        if (HP == 0)
        {
            hpd[0].color = Color.black;
            hpd[1].color = Color.black;
            hpd[2].color = Color.black;
        }
        if (HP == 1)
        {
            hpd[0].color = Color.red;
            hpd[1].color = Color.black;
            hpd[2].color = Color.black;
        }
        if (HP == 2)
        {
            hpd[0].color = Color.red;
            hpd[1].color = Color.red;
            hpd[2].color = Color.black;
        }
        if (HP == 3)
        {
            hpd[0].color = Color.red;
            hpd[1].color = Color.red;
            hpd[2].color = Color.red;
        }
    }

    IEnumerator Iframes()
    {
        iframes = true;
        yield return new WaitForSeconds(IFlen);
        iframes = false;
    }
}
