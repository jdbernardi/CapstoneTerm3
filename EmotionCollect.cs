using UnityEngine;
using System.Collections;
using System;


public class EmotionCollect : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public float attackDamage;               // The amount of health taken away per attack.

    GameObject player;                          // Reference to the player GameObject.
    GameObject wallCollider;
    GameObject floorCollider;
    EmotionalHealth emotionalHealth;                  // Reference to the player's health.
    float timer;                                // Timer for counting up to the next attack.
    OrbProperties emotionOrb;

    public delegate void DestroyAction(string name);
    public static event DestroyAction OnDestroyed;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wallCollider = GameObject.FindGameObjectWithTag("WallCollider");
        floorCollider = GameObject.FindGameObjectWithTag("FloorCollider");

        emotionalHealth = player.GetComponent<EmotionalHealth>();
        emotionOrb = GetComponent<OrbProperties>();
    }

    // TODO: not destroying!!!!
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject == player)
        {
            Attack();
            CallDestroyEvent();
            Destroy(this.gameObject);
        }
        else if (other.gameObject == wallCollider || other.gameObject == floorCollider)
        {
            CallDestroyEvent();
            Destroy(this.gameObject);
        }
        else if(other != this.gameObject)
        {
            if(!this.gameObject.GetComponent<Rigidbody>())
                this.gameObject.AddComponent<Rigidbody>();
        }
    
    }

    void CallDestroyEvent()
    {
        if (OnDestroyed != null)
            OnDestroyed(this.name);
    }

    void Update()
    {
        if (EmotionalHealth.currentEmotion <= 0)
        {
            // code for dead
        }
    }

    void Attack()
    {
        timer = 0f;

        if (EmotionalHealth.currentEmotion > 0)
        {
            attackDamage = GetEmotionValue();
            emotionalHealth.TakeDamage(attackDamage, this.name);
        }
    }

    float GetEmotionValue() // get the value to change the emotionalHealth
    {
        var health = EmotionalHealth.currentEmotion;
        switch (this.name)
        {
            case "happy":
                attackDamage = GetValueForAttack(0, health);
                break;
            case "sad":
                attackDamage = GetValueForAttack(1, health);
                break;
            case "angry":
                attackDamage = GetValueForAttack(2, health);
                break;
            default:
                attackDamage = 1.0f;
                break;
        }
        return attackDamage;
    }

    // TODO: remove hardcoded garbage
    float GetValueForAttack(int eType, float eHealth) 
    {
        if(eType == 0) // if 'happy' check health to return values
        {
            if (eHealth > 50)
                return -1.0f;
            else if (eHealth < 50)
                return 1.0f;
            else
                return 0f;
        } else if(eType == 1) {
            if (eHealth > 50)
                return -3.0f; // less impact if angry
            else
                return -7.0f; // more impact if already sad
        } else if(eType == 2) {
            if (eHealth > 50)
                return 7.0f; // more impact if angry
            else
                return 3.0f; // less impact if sad
        } else {
            return 0;
        }
    }

}