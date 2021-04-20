﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WallRun : MonoBehaviour
{
    //public GameObject thePlayer = GameObject.Find("FPSController");
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public LayerMask wallMask;
    public Transform wallCheckL;
    public Transform wallCheckR;
    public Transform playerCam;
    public float wallDistance = 0.4f; // radius of sphere
    bool isWalled;

    void Start() {
    //controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Are we on the wall?
        if(Physics.CheckSphere(wallCheckL.position, wallDistance, wallMask) || Physics.CheckSphere(wallCheckR.position, wallDistance, wallMask)) {
            isWalled = true;
        } else {
            isWalled = false;
        }

        if(isWalled) {  // resetting the velocity if we hit the ground
            if(Physics.CheckSphere(wallCheckR.position, wallDistance, wallMask) && !controller.m_CharacterController.isGrounded)
                playerCam.Rotate(Vector3.forward,10);  //tilt the cam left if on right wall
            else if(Physics.CheckSphere(wallCheckL.position, wallDistance, wallMask) && !controller.m_CharacterController.isGrounded)
                playerCam.Rotate(Vector3.forward,-10);  //tilt the cam right if on left wall
            controller.m_GravityMultiplier = 1;
            controller.m_RunSpeed = 12;
        } else {
            controller.m_GravityMultiplier = 3;
            controller.m_RunSpeed = 10;
        }
    }
}
