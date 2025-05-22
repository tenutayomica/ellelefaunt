using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController cont;
    public Transform cam;

    public float speed;
    public float jumpSpeed;
    float verticalVelocity;

    public float turnSmoothTime;
    float turnSmoothVelocity;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            cont.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
        Vector3 moveHigh = new Vector3(0, verticalVelocity, 0);
        cont.Move(moveHigh * Time.deltaTime);



        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space) == false)
        {
            jumps = 2;
            verticalVelocity = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {

            verticalVelocity = jumpForce;
        }

        }
        else if (-2 < verticalVelocity && verticalVelocity < 3 && gravAffect)
        {
            verticalVelocity += Physics.gravity.y / 1.4f;

        }
        else if (gravAffect)
        {
            verticalVelocity += grav;
            ground = false;
        }
        else
        {
            verticalVelocity = 0;
        }

        if (verticalVelocity <= -20) verticalVelocity = -20;



    }
}
