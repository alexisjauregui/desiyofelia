using UnityEngine;
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


    // Use this for initialization
    void Start()
    {
        newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
        audio = GetComponent<AudioSource>();
        chords = "";
    }
	// Update is called once per frame
	void Update () {

        newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();

        chords = newText.text;
        //Add combo according to levels here!
        if (SceneManager.GetActiveScene().name == "Level 0")
            pass = "ABYX";
        else if (SceneManager.GetActiveScene().name == "Level 1")
            pass = "XXBA";


		if (chords.Contains(pass))
        {
			Debug.Log ("Yes");
            if (hasPlayed == false)
            {
                hasPlayed = true;
                audio.Play();
            }
            CmdDestroy();
            
        }
        
	}

    [Command]
    void CmdDestroy()
    {
        GameObject networkCage = GameObject.FindGameObjectWithTag("Cage");
        NetworkServer.Destroy(networkCage);
    }

    
}
