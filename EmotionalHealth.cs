using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class EmotionalHealth : MonoBehaviour {

    public static float currentEmotion;
    public Slider emotionSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 10f; // damage image
    public Color flashColor = new Color(1.0f, 0.0f, 0f, 1.0f);
    bool damaged = false;
    public HeadMovement playerMovement; // something to stop the player from moving when losing

    public delegate void HappyCollect();
    public static event HappyCollect HappyCollected;

    public AudioClip happySound, sadSound, angrySound;
    public GameObject happy, sad, angry;
    private GvrAudioSource happySrc, sadSrc, angrySrc;

    void Awake()
    {
        currentEmotion = DetermingStartingHealthBasedOnStartSelection();
        emotionSlider.value = currentEmotion;
    }

    void Start()
    {
        happySrc = happy.GetComponent<GvrAudioSource>();
        sadSrc = sad.GetComponent<GvrAudioSource>();
        angrySrc = angry.GetComponent<GvrAudioSource>();
    }

	void Update () 
    {
		if(damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime); 
        }
        damaged = false;
	}

    public void TakeDamage(float amount, string emotion)
    {
        damaged = true;
        currentEmotion += amount;
        emotionSlider.value = currentEmotion;
        PlaySoundEffect(emotion);
        if (currentEmotion <= 1 || currentEmotion >= 100)
        {
            Debug.Log("DEATH");
            Death();
        }
    }

    void PlaySoundEffect(string emotion)
    {
        if (emotion == "happy")
        {
            if (HappyCollected != null)
                HappyCollected();
            
            //happySrc = happy.GetComponent<GvrAudioSource>();
            happySrc.PlayOneShot(happySrc.clip);
        } else if (emotion == "sad") {
            //sadSrc = sad.GetComponent<GvrAudioSource>();
            sadSrc.PlayOneShot(sadSrc.clip);
        } else if (emotion == "angry") {
            //angrySrc = angry.GetComponent<GvrAudioSource>();
            angrySrc.PlayOneShot(angrySrc.clip);
        } else
            Debug.Log("Nothing");
    }

    float DetermingStartingHealthBasedOnStartSelection()
    {
        string selectedEmotion = LevelManager.playerStartSelect;
        switch (selectedEmotion)
        {
            case "happy":
                return 50.0f;
            case "sad":
                return 35.0f;
            case "angry":
                return 65.0f;
            default:
                return 50.0f;
        }
    }

    void Death()
    {
        Time.timeScale = 0;

        // play losing audio?

        SceneManager.LoadScene("End");
    }
}
