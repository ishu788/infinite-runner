using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 2.0f;
    private float vertialVelocity = 0.0f;
    private float gravity = 12f;
    private float animationDuration = 3.0f;


    private bool isDead = false;
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
        {
            return;
        }

        if(Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;

        if(controller.isGrounded)
        {
            vertialVelocity = 0.0f;
        }
        else
        {
            vertialVelocity -= gravity;
        }


        moveVector.z = speed;
        moveVector.y = vertialVelocity;
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        controller.Move(moveVector * speed * Time.deltaTime );
	}

    public void SetSpeed(float modifier)
    {
        speed = 1.0f + modifier;
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.point.z > transform.position.z + controller.radius)
        {
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }

}
