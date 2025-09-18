using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VictimScript : MonoBehaviour
{
    public List<GameObject> Obstacles;
    public Transform Destination;
    public bool safe = false;
    public NavMeshAgent agent;
    public Animator ani;


    void Update()
    {
        foreach (GameObject Obstaculo in Obstacles) if (Obstaculo == null) Obstacles.Remove(Obstaculo);
        if (Obstacles.Count == 0) safe = true;
        if (safe) ani.SetBool("InDanger", false);
        if (safe) agent.destination = Destination.position;
    }

    IEnumerator Saved()
    {
        yield return new WaitForSeconds(0.5f);
        agent.destination = Destination.position;
    }
}
