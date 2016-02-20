using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

/*
  Code made to check if player made correct combination of keys;

*/ 

public class checkChords : NetworkBehaviour {

    public string pass;
    private string chords;
    private GameObject Cage;
    private Text newText;
    public AudioSource audio;
    bool hasPlayed = false;

    // Use this for initialization
    void Start()
    {
        newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
        audio = GetComponent<AudioSource>();
        chords = "";
        Cage = GameObject.FindGameObjectWithTag("Cage");
    }
	// Update is called once per frame
	void Update () {

        newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();

        chords = newText.text;

  
     

        if (chords== pass)
        {
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
        NetworkServer.Destroy(Cage);
    }
}
