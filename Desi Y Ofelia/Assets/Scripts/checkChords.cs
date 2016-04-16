﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

/*
  Code made to check if player made correct combination of keys;

*/ 

public class checkChords : NetworkBehaviour {

    private string pass;
    private string chords;
    private Text newText;
    public AudioSource audio;
    bool hasPlayed = false;
    private ParticleSystem particle;


    // Use this for initialization
    void Start()
    {
        newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
        audio = GetComponent<AudioSource>();
        chords = "";
        particle = GameObject.Find("bannerRain").GetComponent<ParticleSystem>();
        particle.Pause();
    }
	// Update is called once per frame
	void Update () {
        Debug.Log(particle.isPlaying);
        if (SceneManager.GetActiveScene().name == "Level 0" || SceneManager.GetActiveScene().name == "Level 1")
        {

            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();

            chords = newText.text;
            //Add combo according to levels here!
            if (SceneManager.GetActiveScene().name == "Level 0")
            {
                pass = "ABYX";
                
                
            }
            else if (SceneManager.GetActiveScene().name == "Level 1")
                pass = "XXBA";


            if (chords.Contains(pass))
            {
                Debug.Log("Yes");
                if (hasPlayed == false)
                {
                    hasPlayed = true;
                    audio.Play();
                }
                CmdDestroy();

            }

            if (hasPlayed)
            {
                particle.Play();
                Debug.Log("HolllA");
            }
        }
        
	}

    [Command]
    void CmdDestroy()
    {
        GameObject networkCage = GameObject.FindGameObjectWithTag("Cage");
        NetworkServer.Destroy(networkCage);
    }

    
}
