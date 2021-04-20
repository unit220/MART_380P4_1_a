using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool inTrigger;
    public AudioSource playSound;
    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        //Debug.Log("Trigger");'
        playSound.Play();
        inTrigger = true;
    }
}
