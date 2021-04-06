using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float moveSpeed = 12f;
    public float gravity = -9.807f; // ~Earth grav by default
    public float jumpHeight = 4f;
    Vector3 veloctiy;

    public Transform groundCheck;
    public float groundDistance = 0.4f; // radius of sphere
    public LayerMask groundMask;
    bool isGrounded;
    bool isCrouching;

    // Update is called once per frame
    void Update()
    {
        // Are we on the ground?
        // Works by creating a tiny sphere at the groundCheck and checks for collision. If we have it, we grounded!
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && veloctiy.y < 0) {  // resetting the velocity if we hit the ground
            veloctiy.y = -2f; // -2 makes sure we're actually hitting the ground and not just floating a little bit off
        }

        // Get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate how to move the player *relative* to where they are now
        Vector3 move = transform.right*x+transform.forward*z;
        // Moves the player based off their position, speed, and time (time is just to remove FPS dependance)
        controller.Move(move*moveSpeed*Time.deltaTime);

        // Jumping
        // amount of v needed to jump x units is = sqrt(heigh*-2*gravity)
        if(Input.GetButtonDown("Jump") && isGrounded) {
            veloctiy.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Calculate gravity's affect on the player
        veloctiy.y += gravity * Time.deltaTime;
        // Move the player, deltaTime here accelerates the player like a real free fall
        // as the equation for deta(y)=0.5g*t^2 so we square time here by a simple double mult
        controller.Move(veloctiy*Time.deltaTime);

        // Crouching is now done in its own script, go there (code saved for support)
        // Check crouch state
        // if(Input.GetKeyDown(KeyCode.LeftControl)) {
        //     if (isCrouching) {
        //         isCrouching = false;
        //     } else {
        //         isCrouching = true;
        //     }
        // }
        // // do the crouching
        // if(isCrouching) {
        //     controller.height = 0.8f; // heigh while crouched
        //     transform.position = new Vector3(transform.position.x, transform.position.y-0.4f, transform.position.z);
        // } else {
        //     controller.height = 1f; // regular height
        // }
    }
}
