using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject orb;
    private float spawningRate;
    private float range, zRange; // set limits for spawning locations on y axis
    OrbProperties orbProperties;

    public GameObject streak;

    public static float weightForLastOrbDestroyed = 0;

    public void OnEnable()
    {
        EmotionCollect.OnDestroyed += SetLastOrbDestroyed;
    }

    public void OnDisable()
    {
        EmotionCollect.OnDestroyed -= SetLastOrbDestroyed;    
    }

    void SetLastOrbDestroyed(string destroyedOrb)
    {
        switch(destroyedOrb)
        {
            case "happy":
                weightForLastOrbDestroyed = 0;
                break;
            case "sad":
                weightForLastOrbDestroyed = 1;
                break;
            case "angry":
                weightForLastOrbDestroyed = 2;
                break;
            default:
                weightForLastOrbDestroyed = 0;
                break;
        }
    }

    void Start () 
    {
        spawningRate = 2.0f;
        weightForLastOrbDestroyed = 0;
        range = 10.0f;
        zRange = 4.0f;

        Invoke("SpawnOrb", GetSpawningRate());
        InvokeRepeating("IncreaseSpawnRate", 5.0f, 5.0f);  // not delay cause
	}

    void SpawnOrb()
    {
        float xPos = 200.0f;
        float zPos = -1.0f;
        var clone = Instantiate(orb, new Vector3(xPos, UnityEngine.Random.Range(-range, range), zPos), Quaternion.identity);
        var cloneStreak = Instantiate(streak, new Vector3(xPos, UnityEngine.Random.Range(-range, range), UnityEngine.Random.Range(-zRange, zRange)), Quaternion.identity);
        orbProperties = clone.GetComponent<OrbProperties>();
        Invoke("SpawnOrb", GetSpawningRate());
    }


    float GetSpawningRate()
    {
        return spawningRate;
    }
	

    void IncreaseSpawnRate()
    {
        spawningRate /= 1.05f;
    }


	void Update () {

	}

}
