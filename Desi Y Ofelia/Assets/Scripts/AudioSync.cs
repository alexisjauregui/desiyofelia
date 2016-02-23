using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioSync : NetworkBehaviour {

    private AudioSource source;

	// Use this for initialization
	void Start () {
	    
	}
	
    public void PlaySound(AudioSource audiosource)
    {
        CmdSendServerSound(audiosource);
    }

	[Command]
    void CmdSendServerSound(AudioSource audiosource)
    {
        RpcSendSoundToClient(audiosource);
    }

    [ClientRpc]
    void RpcSendSoundToClient(AudioSource audiosource)
    {
        audiosource.Play();
    }
}
