using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
   [Range(0,50)] [SerializeField] float attackRange = 5, sightRange = 20, timeBetweenAtacks = 2;
    Vector3 playerPos;
    private NavMeshAgent thisEnemy;
    private bool isAttacking;
    GameObject playerGO;
    float distanceFromPlayer;
    Vector3 inicio;
    Vector3 fin;
    Vector3 patrolDestination;
    public float speed;
    [SerializeField] private float timer = 5;
    private float bulletTime;
    public GameObject enemyProjectile;
    public Transform spawnPoint;
    public float force;
    Vector3 aim;
    GameObject startGo;
    GameObject endGo;
    private void Start()
    {
        thisEnemy = GetComponent<NavMeshAgent>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        startGo = GameObject.FindGameObjectWithTag("startPoint");
        endGo = GameObject.FindGameObjectWithTag("endPoint");
        inicio = startGo.transform.position;
        fin = endGo.transform.position;
        patrolDestination = inicio;
    }
    private void Update()
    {
        playerPos = playerGO.transform.position;
        distanceFromPlayer = Vector3.Distance(playerPos, transform.position);
        if(GetComponentInChildren<Fire>().life == 0)
        {
            Destroy(this.gameObject);
        }
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
        shoot();
        isAttacking = false;
        thisEnemy.isStopped = false;
    }
    void shoot()
    {
        //bulletTime -= Time.deltaTime;
        //if (bulletTime > 0) return;
        bulletTime = timer;
        GameObject projectileObj = Instantiate(enemyProjectile, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody projectileRig = projectileObj.GetComponent<Rigidbody>();
        projectileRig.AddForce(projectileRig.transform.forward * force,ForceMode.Impulse);
       // Destroy(projectileObj, 0.1f);
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
        
        if (!thisEnemy.pathPending && thisEnemy.remainingDistance < 0.5f)
        {
            
            patrolDestination = (patrolDestination == inicio) ? fin : inicio;
            thisEnemy.SetDestination(patrolDestination);
        }
    }
}
