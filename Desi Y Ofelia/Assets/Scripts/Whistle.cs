using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Whistle : NetworkBehaviour {
    public AudioClip clip;
    private AudioSource audiosource;


    // Use this for initialization
    void Start()
    {
        audiosource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (isLocalPlayer)
        {
            if (Input.GetButtonDown("BButton"))
            {
                RpcPlayWhistle();
            }
        }
	
	}

    [ClientRpc]
    void RpcPlayWhistle()
    {
        audiosource.Play();
    }

}
