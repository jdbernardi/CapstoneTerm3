using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour 
{
    public GameObject panel;

    public static string playerStartSelect;

    void Start()
    {
        Time.timeScale = 1.0f; // prevents game freezing up on quick Restart

        if (panel != null)
            panel.SetActive(false);
    }

    public void LoadScene(string name)
    {
        if(name == "Game")
            playerStartSelect = this.name;
        if (panel != null)
            panel.SetActive(true);

        Application.backgroundLoadingPriority = ThreadPriority.Low;
        SceneManager.LoadSceneAsync(name);


    }
}
