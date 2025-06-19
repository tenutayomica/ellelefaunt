using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHP = 3;
    public int HP = 3;
    private int pastHP = 3;
    public bool iframes = false;
    public float IFlen;

    void Update()
    {
        if (HP <= 0) GetComponentInParent < DeathManager >().Muerte();
        if (HP < pastHP) StartCoroutine(Iframes());
        pastHP = HP;
    }

    IEnumerator Iframes()
    {
        iframes = true;
        yield return new WaitForSeconds(IFlen);
        iframes = false;
    }
}
