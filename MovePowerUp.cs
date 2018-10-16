using System.Collections;
using System.Collections.Generic;
using UnityEngine;using System;

public class MovePowerUp : MonoBehaviour {

    private float speed;

	// Use this for initialization
	void Start () 
    {
        speed = 125.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(this)
            transform.Translate(Vector3.back * Time.deltaTime * speed);
	}
}
