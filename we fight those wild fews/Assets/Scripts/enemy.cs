using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
   [Range(0,50)] [SerializeField] float attackRange = 5, sightRange = 20, timeBetweenAtacks = 3;
    Vector3 playerPos;
    private NavMeshAgent thisEnemy;
    private bool isAttacking;
    GameObject playerGO;
    private void Start()
    {
        thisEnemy = GetComponent<NavMeshAgent>();
        playerGO = GameObject.FindGameObjectWithTag("Player");

    }
    private void Update()
    {
        //thisEnemy.SetDestination(playerPos);
        playerPos = playerGO.transform.position;
        float distanceFromPlayer = Vector3.Distance(playerPos, this.transform.position);
        if (distanceFromPlayer <= sightRange && distanceFromPlayer > attackRange)
        {
            if(thisEnemy.isStopped)
                ChasePlayer();
        }
        if (distanceFromPlayer <= sightRange && !isAttacking)
        {
            if(!isAttacking)
                StartCoroutine(AttackPlayer());
        }
    }
    private void ChasePlayer()
    {
        Debug.LogWarning("i chase");
        StopAllCoroutines();
        isAttacking = false;
        thisEnemy.isStopped = false;
        thisEnemy.SetDestination(playerPos);
    }
    private IEnumerator AttackPlayer()
    {
        thisEnemy.isStopped = true;
        isAttacking = true;
        yield return new WaitForSeconds(timeBetweenAtacks);
        Debug.Log("hurt");
        isAttacking = false;    
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange); 
        
    }
}
