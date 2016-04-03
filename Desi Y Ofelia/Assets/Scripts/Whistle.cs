using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Whistle : NetworkBehaviour {
    public AudioClip clip;
    private AudioSource source;


    // Use this for initialization
    void Start()
    {
        source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (isLocalPlayer)
        {
            if (Input.GetButtonDown("AButton"))
            {
                source.Play();
            }
        }
	
	}

}
