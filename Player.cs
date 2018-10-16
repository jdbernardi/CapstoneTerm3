using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour {



    public GameObject powerUpObject;
    public Text powerUpCountText;
    private Vector3 playerPositionAtCenter;
    private float speed = 150.0f;
    private int numPowerups;
    private int collectedHappyEmotions;
    private GameObject cloneToDestroy;



    private void OnEnable()
    {
        EmotionalHealth.HappyCollected += CheckPowerUpsAndIncrement;
    }

    private void OnDisable()
    {
        EmotionalHealth.HappyCollected -= CheckPowerUpsAndIncrement;
    }

    private void Start()
    {
        playerPositionAtCenter = new Vector3(19.3f, 0.0f, -1.0f);
        numPowerups = 3;
        powerUpCountText.text = numPowerups.ToString();
        collectedHappyEmotions = 0;
    }

    public GameObject SpawnPowerUp()
    {
        GameObject clone = Instantiate(powerUpObject, playerPositionAtCenter, Quaternion.identity);
        clone.transform.Rotate(0.0f, -90.0f, 0.0f);

        return clone;
    }

    private void Update()
    {
        if (EnoughPowerUps())
        {
            GameObject clone;

            if (Input.GetMouseButtonDown(0))
            {
                clone = SpawnPowerUp();
                AdjustNumPowerUps();
                clone.transform.Translate(Vector3.back * Time.deltaTime * speed);
                cloneToDestroy = clone;
                Invoke("DestroyClone", 4.0f);
            }
            else
            {
                clone = null;
            }

            powerUpCountText.text = numPowerups.ToString();
        }
    }


    void CheckPowerUpsAndIncrement()
    {
        collectedHappyEmotions++;
        if (collectedHappyEmotions % 5 == 0 && collectedHappyEmotions != 0)
        {
            if ((numPowerups < 5))
            {
                numPowerups++;
            }
        }
    }

    bool EnoughPowerUps()
    {
        if (numPowerups > 0)
            return true;

        return false;
    }

    void AdjustNumPowerUps()
    {
        if (numPowerups > 0)
            numPowerups--;
    }

    void DestroyClone()
    {
        //yield return new WaitForSeconds(3.0f);
        Destroy(cloneToDestroy);
    }

}
