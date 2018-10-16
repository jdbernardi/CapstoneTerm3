using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OrbProperties : MonoBehaviour {
    
    public List<Material> materials = new List<Material>(); // matches Enum | 0 = happy | 1 = sad | 2 = angry
    public float pointValue; // controls meter

    public enum Emotion : int { happy, sad, angry };

    // Use this for initialization
    void Start () 
    {
        Renderer orb = GetComponent<Renderer>();
        Weight = -1;
        int num = GetNextOrbToSpawn();
        orb.material = materials[num];
        SetSpeed(num);
        SetEmotionAndResize(num);
	}

    public float Weight { get; set; }

    public float Speed { private get; set;  }
	
	// Update is called once per frame
	void Update () 
    {
        if (Speed <= 0)
            return;
        this.transform.Translate(Vector3.left * Time.deltaTime * Speed);
	}

    // TODO: refactor this mess
    int GetNextOrbToSpawn()
    {
        int num = (int)Spawner.weightForLastOrbDestroyed;
        float pctEmotionHealth = EmotionalHealth.currentEmotion / 100;
        float remainder = (1 - pctEmotionHealth) / 2;

        if (num == 0)
        {
            var list = new[] {
                ProportionValue.Create(pctEmotionHealth, 0),
                ProportionValue.Create(remainder, 1),
                ProportionValue.Create(remainder, 2)
            };
            return list.ChooseByRandom();
        } else if(num == 1){
            var list = new[] {
                ProportionValue.Create(remainder, 0),
                ProportionValue.Create(pctEmotionHealth, 1),
                ProportionValue.Create(remainder, 2)
            };
            return list.ChooseByRandom();
        } else if(num == 2){
            var list = new[] {
                ProportionValue.Create(remainder, 0),
                ProportionValue.Create(remainder, 1),
                ProportionValue.Create(pctEmotionHealth, 2)
            };  
            return list.ChooseByRandom();
        } else {
            var list = new[] {
                ProportionValue.Create(pctEmotionHealth, 0),
                ProportionValue.Create(remainder, 1),
                ProportionValue.Create(remainder, 2)
            };
            return list.ChooseByRandom();
        }
    }

    void SetEmotionAndResize(int num)
    {
        switch (num)
        {
            case 0:
                this.name = "happy";
                this.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
                break;
            case 1:
                this.name = "sad";
                this.transform.localScale = new Vector3(7.0f, 7.0f, 7.0f);
                break;
            case 2:
                this.name = "angry";
                this.transform.localScale = new Vector3(7.0f, 7.0f, 7.0f);
                break;
            default:
                Debug.Log("ERROR::no orb name assigned");
                break;
        }
    }


    // TODO: incorporate time
    void SetSpeed(int num)
    {
        float happyFactor = 0.7f;
        float sadFactor = 0.5f;
        float angryFactor = 0.9f;
        float tempSpeed;
        var currHealth = EmotionalHealth.currentEmotion;

        switch (num)
        {
            case 0:
                 tempSpeed = happyFactor * currHealth;
                break;
            case 1:
                tempSpeed = sadFactor * currHealth;
                break;
            case 2:
                tempSpeed = angryFactor * currHealth;
                break;
            default:
                tempSpeed = happyFactor * currHealth;
                break;
        }
        Speed = tempSpeed;
    }

}
