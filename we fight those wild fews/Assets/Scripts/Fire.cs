using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int life = 1;
     void OnParticleTrigger()
    {
        Debug.Log("entraaaaaaaaaaaa");
        ParticleSystem ps = GetComponent<ParticleSystem>();
        List<ParticleSystem.Particle> enterList = new List<ParticleSystem.Particle>();
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterList);
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enterList[i];
            life -= 1;
            Debug.Log("Life decreased, current life: " + life);

            if (life <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("muere");
                break; 
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<HealthManager>().iframes == false)
        {
            other.gameObject.GetComponent<HealthManager>().HP -= 1;
        }
    }
}
