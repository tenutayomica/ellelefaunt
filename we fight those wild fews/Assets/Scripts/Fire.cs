using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int life = 3;
    public List<ParticleSystem> flames;
    public List<ParticleSystem.MinMaxCurve> lifetimes;
    bool iframes = false;

    void Start()
    {
        flames.Add(GetComponentsInChildren<ParticleSystem>()[0]);
        flames.Add(GetComponentsInChildren<ParticleSystem>()[1]);
        flames.Add(GetComponentsInChildren<ParticleSystem>()[2]);
        lifetimes[0] = flames[0].main.startLifetime;
        lifetimes[1] = flames[1].main.startLifetime;
        lifetimes[2] = flames[2].main.startLifetime;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<HealthManager>().iframes == false && life > 0)
        {
            other.gameObject.GetComponent<HealthManager>().HP -= 1;
        }
        if (other.gameObject.tag == "Extermination cube")
        {
            Debug.Log("entra");
            if (GameObject.Find("wawa").GetComponent<wawa>().watermeter > 0 && !GameObject.Find("wawa").GetComponent<wawa>().dryActivity)
            {
                if( Input.GetButton("Fire1") && !iframes)
                {
                    iframes = true;
                    life -= 1;
                    if (life == 2)
                    {
                    ParticleSystem.MainModule mainZero = flames[0].main;
                    ParticleSystem.MinMaxCurve zeroCurve = new ParticleSystem.MinMaxCurve(4.5f);
                    mainZero.startLifetime = zeroCurve;
                    ParticleSystem.MainModule mainOne = flames[1].main;
                    ParticleSystem.MinMaxCurve oneCurve = new ParticleSystem.MinMaxCurve(1.5f);
                    mainOne.startLifetime = oneCurve;
                    ParticleSystem.MainModule mainTwo = flames[2].main;
                    ParticleSystem.MinMaxCurve twoCurve = new ParticleSystem.MinMaxCurve(0.75f);
                    mainTwo.startLifetime = twoCurve;
                    }
                    if (life == 1)
                    {
                    ParticleSystem.MainModule mainZero = flames[0].main;
                    ParticleSystem.MinMaxCurve zeroCurve = new ParticleSystem.MinMaxCurve(3f);
                    mainZero.startLifetime = zeroCurve;
                    ParticleSystem.MainModule mainOne = flames[1].main;
                    ParticleSystem.MinMaxCurve oneCurve = new ParticleSystem.MinMaxCurve(1f);
                    mainOne.startLifetime = oneCurve;
                    ParticleSystem.MainModule mainTwo = flames[2].main;
                    ParticleSystem.MinMaxCurve twoCurve = new ParticleSystem.MinMaxCurve(0.5f);
                    mainTwo.startLifetime = twoCurve;
                    }
                    if (life == 0)
                    {
                    ParticleSystem.MainModule mainZero = flames[2].main;
                    ParticleSystem.MinMaxCurve zeroCurve = new ParticleSystem.MinMaxCurve(0f);
                    mainZero.startLifetime = zeroCurve;
                    ParticleSystem.MainModule mainOne = flames[0].main;
                    ParticleSystem.MinMaxCurve oneCurve = new ParticleSystem.MinMaxCurve(0f);
                    mainOne.startLifetime = oneCurve;
                    ParticleSystem.MainModule mainTwo = flames[1].main;
                    ParticleSystem.MinMaxCurve twoCurve = new ParticleSystem.MinMaxCurve(0f);
                    mainTwo.startLifetime = twoCurve;
                    }

                    StartCoroutine(Damage());
                    Debug.Log("low");
                }
                
            }

        }
        if (life <= 0)
        {
            StartCoroutine(Death());
            Debug.Log("muere");
            
        }
    }

    IEnumerator Damage()
    {
        yield return new WaitForSeconds(0.2f);
        iframes = false;
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
