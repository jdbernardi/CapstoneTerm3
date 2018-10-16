using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour {

    private static float CurrentScore = 0.0f;
    public static float savedScore;

    private Text scoreDisplay;

	void Start () 
    {
        scoreDisplay = GetComponent<Text>();
        if(this.name == "endScore")
            scoreDisplay.text = (((int)(CurrentScore)).ToString() + "\tEmeters");
        else
            CurrentScore = 0.0f; // reset just in case
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (this.name == "endScore")
            return;
        float speedIncrement = (1.0f / EmotionalHealth.currentEmotion); // makes meter dynamic to speed based on health
        CurrentScore += (Time.deltaTime * (1.0f / speedIncrement));
        scoreDisplay.text = (((int)(CurrentScore)).ToString() + "\tEmeters");
	}
}
