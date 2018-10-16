using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthImageControl : MonoBehaviour {

    SpriteRenderer img;
    public Sprite[] images = new Sprite[4];
    private float health;

    private float minXPos;
    private float factorToMoveBy;

    private Transform startMarker;

	// Use this for initialization
	void Start () {
        float xPositions = 31.0f; // num positions along the x axis so 6 - 36 is 31 stops
        float totalHealth = 100.0f;

        factorToMoveBy = xPositions / totalHealth;
        img = GetComponent<SpriteRenderer>();
        minXPos = -12.0f;
	}
	
	// Update is called once per frame
    void Update () {
        health = EmotionalHealth.currentEmotion;
        UpdatePositionOfSmiley();

        if (health > 40 && health < 60)
            img.sprite = images[0];
        else if (health <= 25)
            img.sprite = images[1];
        else if (health >= 75)
            img.sprite = images[2];
        else if ((health < 75 && health >=60) || (health > 25 && health <= 40))
            img.sprite = images[3];        
        else
            img.sprite = images[0];

	}

    void UpdatePositionOfSmiley()
    {
        float xPos = ((minXPos + (factorToMoveBy * (health - 1)))); // funky math to math the units to move along the health bar
        this.transform.position = new Vector3(xPos, this.transform.position.y, this.transform.position.z);
    }
}
