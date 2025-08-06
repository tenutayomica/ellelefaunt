using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VictimScript : MonoBehaviour
{
    public List<GameObject> Obstacles;
    public Transform Destination;
    bool safe = false;
    public NavMeshAgent agent;


    void Update()
    {
        foreach (GameObject Obstaculo in Obstacles) if (Obstaculo == null) Obstacles.Remove(Obstaculo);
        if (Obstacles.Count == 0) safe = true;
        if (safe) agent.destination = Destination.position;
    }
}
