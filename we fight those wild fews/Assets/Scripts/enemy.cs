using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
   // public static event Action<enemy> OnEnemyKilled; 
    public float health, maxhealth = 3f;
    public float enemySpeed = 5f;
    Rigidbody rb; 
    public Transform target; 
    Vector2 moveDirection;
    void awake()
    {
       rb = GetComponent<Rigidbody>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        health= maxhealth;
        target= GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(target){
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
            //rb.rotation = angle;
            moveDirection= direction;
        }
        
        
    }
    void FixedUpdate()
    {
       //rb.velocity= new Vector2(moveDirection.x, moveDirection.y)*moveSpeed; 
    }
}
