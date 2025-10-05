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
    public float jumpForce;
    public Animator ani;
    public float turnSmoothTime;
    float turnSmoothVelocity;
    bool walk;
    public bool grounded;
    public bool locked = false;

    void Update()
    {
        if (Physics.Raycast(this.gameObject.transform.position, Vector3.down, 1.5f)) grounded = true;
        else grounded = false;
            float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f && !locked)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            cont.Move(moveDir.normalized * speed * Time.deltaTime);
            ani.SetBool("Moving", true);
        }
        else
        {
            ani.SetBool("Moving", false);
        }
        
        Vector3 moveHigh = new Vector3(0, verticalVelocity, 0);
        cont.Move(moveHigh * Time.deltaTime);



        if (grounded && Input.GetKeyDown(KeyCode.Space) && !locked)
        {
            verticalVelocity = jumpForce;
            ani.SetTrigger("Jump");
        }
        else if (cont.isGrounded)
        {
            verticalVelocity = 0;
        }
        else if (-2 < verticalVelocity && verticalVelocity < 3)
        {
            verticalVelocity += Physics.gravity.y / 24f;

        }
            verticalVelocity += Physics.gravity.y / 20f;

        if (verticalVelocity <= -20) verticalVelocity = -20;

        if (grounded) ani.SetBool("Grounded", true);
        else ani.SetBool("Grounded", false);

    }
}
