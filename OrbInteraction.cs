using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OrbInteraction : MonoBehaviour {

    float originalY;
    float eTime;

    public float floatStrength = 1; // how much they move up and down 

    void Start()
    {
        this.originalY = this.transform.position.y;
        SetTimeVal();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
        originalY + ((float)Mathf.Sin(SetTimeVal()) * floatStrength),
        transform.position.z);
    }

    float SetTimeVal()
    {
        if(this.name == "happy")
        {
            eTime = Time.time;
        } else if(this.name == "sad") {
            eTime = Time.time * 0.5f;
        } else if(this.name == "angry"){
            eTime = Time.time * 2.5f;
        } else {
            eTime = Time.time;
        }

        return eTime;
    }
}
