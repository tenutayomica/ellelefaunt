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
    private void Start()
    {
        thisEnemy = GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        float distanceFromPlayer = Vector3.Distance(playerPos, this.transform.position);
        if(distanceFromPlayer<=sightRange && distanceFromPlayer > attackRange)
        {
            isAttacking = false;
            StopAllCoroutines();
            ChasePlayer();
            thisEnemy.isStopped = false; 
        }
        if(distanceFromPlayer <= sightRange && !isAttacking)
        {
            thisEnemy.isStopped = true;
            StartCoroutine(AttackPlayer()); 
        }
    }
    private void ChasePlayer()
    {
        thisEnemy.SetDestination(playerPos);
    }
    private IEnumerator AttackPlayer()
    {
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
