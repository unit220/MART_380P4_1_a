using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public bool hitPlayer;


    void Start() {
        //Collider myCollider = <SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float disatanceThisFrame = speed*Time.deltaTime;

        // hitting the target
        if(direction.magnitude <= disatanceThisFrame) {
            HitPlayer();
            return;
        }

        // moving
        transform.Translate(direction.normalized * disatanceThisFrame, Space.World);
    }

    void HitPlayer() {
        Debug.Log("You've been hit!");
        hitPlayer = true;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "FPSController") {
            Debug.Log("Collision detected");
        }
    }

    // Checks less often for pref reasons
    // void seek(Transform _target) {
    //     //player = _target
    // }
}
