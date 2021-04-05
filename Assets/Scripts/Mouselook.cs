using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // deltaTime = time since update was last called, helps standardize movement between FPS
        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;

        // moves camera up and down with mouse
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // prevents looking behind you
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // moves entire playermodel left and right with mouse
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
