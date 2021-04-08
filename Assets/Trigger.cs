using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool inTrigger;
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
        inTrigger = true;
    }
}
