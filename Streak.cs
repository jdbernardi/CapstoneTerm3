using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Streak : MonoBehaviour {

    private float speed;

	// Use this for initialization
	void Start () 
    {
        SetSpeed();
        Invoke("DestroyStreak", 4.0f);
	}
	
    void Update()
    {
        if (speed <= 0)
            return;
        this.transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    void SetSpeed()
    {
        speed = 250;
    }

    void DestroyStreak()
    {
        Destroy(this.gameObject);
    }
}
