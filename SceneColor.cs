using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneColor : MonoBehaviour {

    Camera cam;
    Color currentColor;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
	}
	
	// Update is called once per frame
	void Update () {
		ChangeBackDropBasedOnHealth();
	}


    void ChangeBackDropBasedOnHealth()
    {
        float num = EmotionalHealth.currentEmotion;
        float healthProportion = num /200.0f;
        if(num >= 50)
        {
            currentColor = Color.Lerp(Color.yellow, Color.red, healthProportion);
        } else if(num < 50) {
            currentColor = Color.Lerp(Color.yellow, Color.blue, healthProportion);
        }
        cam.backgroundColor = currentColor;
    }
}
