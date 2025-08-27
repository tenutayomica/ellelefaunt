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
    float distanceFromPlayer;
    public Vector3 inicio;
    public Vector3 fin;
    Vector3 movlin;
    public float speed = 5f; 
    private void Start()
    {
        thisEnemy = GetComponent<NavMeshAgent>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        inicio = new Vector3(2, 2, 30);
        fin = new Vector3(2, 2, 40);
        movlin = fin; 


    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movlin, speed * Time.deltaTime);
        //thisEnemy.SetDestination(playerPos);
        playerPos = playerGO.transform.position;
        distanceFromPlayer = Vector3.Distance(playerPos, this.transform.position);
        if (distanceFromPlayer > sightRange && distanceFromPlayer> attackRange)
        {
            stroll();
        }
        if (distanceFromPlayer <= sightRange && distanceFromPlayer > attackRange)
        {
            
                ChasePlayer();
        }
        if (distanceFromPlayer <= attackRange && !isAttacking)
        {
            if(!isAttacking)
                StartCoroutine(AttackPlayer());
        }
    }
    private void ChasePlayer()
    {
        StopAllCoroutines();
        isAttacking = false;
        thisEnemy.isStopped = false;
        thisEnemy.destination = playerPos;
        Debug.LogWarning("i chase");
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
    private void stroll()
    {
        if (Vector3.Distance(transform.position, movlin) < 1.0f)
        {
            movlin = (movlin == inicio) ? fin : inicio;
            thisEnemy.SetDestination(movlin);
        }
        thisEnemy.SetDestination(movlin);
    }
}
