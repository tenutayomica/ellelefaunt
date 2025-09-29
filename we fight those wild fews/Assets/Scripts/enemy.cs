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
    Vector3 patrolDestination;
    public float speed = 5f;
    [SerializeField] private float timer = 5;
    private float bulletTime;
    public GameObject projectile;
    public Transform spawnPoint;
    
    private void Start()
    {
        thisEnemy = GetComponent<NavMeshAgent>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        inicio = new Vector3(2, 2, 30);
        fin = new Vector3(2, 2, 40);
        patrolDestination = inicio; 



    }
    private void Update()
    {
        playerPos = playerGO.transform.position;
        distanceFromPlayer = Vector3.Distance(playerPos, transform.position);

        if (distanceFromPlayer <= attackRange)
        {
            if (!isAttacking)
            {
                StartCoroutine(AttackPlayer());
            }
        }
        else if (distanceFromPlayer <= sightRange)
        {
            ChasePlayer();
        }
        else
        {
            stroll();
        }
    }
    private void ChasePlayer()
    {
        StopAllCoroutines();
        isAttacking = false;
        thisEnemy.isStopped = false;
        thisEnemy.SetDestination(playerPos);
        Debug.LogWarning("i chase");
    }
    private IEnumerator AttackPlayer()
    {
        thisEnemy.isStopped = true;
        isAttacking = true;
        yield return new WaitForSeconds(timeBetweenAtacks);
        Debug.Log("The player gets hurt!");
        bulletTime -= Time.deltaTime;
        //if (bulletTime > 0) return;
        bulletTime = timer;
        GameObject projectileobj = Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody projectilerig = projectileobj.GetComponent<Rigidbody>();
        projectilerig.AddForce(projectilerig.transform.forward * speed);
        Destroy(projectileobj, 0.1f);
        isAttacking = false;
        thisEnemy.isStopped = false;
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
        // Check if the enemy has reached its patrol destination
        if (!thisEnemy.pathPending && thisEnemy.remainingDistance < 0.5f)
        {
            // Switch the patrol destination
            patrolDestination = (patrolDestination == inicio) ? fin : inicio;
            thisEnemy.SetDestination(patrolDestination);
        }
    }
}
