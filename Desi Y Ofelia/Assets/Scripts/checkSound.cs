using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class checkSound : NetworkBehaviour
{

    public AudioClip[] clips;

    private AudioSource audiosource;


    void Start()
    {
        audiosource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer)
        {
            if (Input.GetButtonDown("AButton"))
            {
                PlaySound(0);
            }
            if (Input.GetButtonDown("BButton"))
            {
                PlaySound(1);
            }
            if (Input.GetButtonDown("XButton"))
            {
                PlaySound(2);
            }
            if (Input.GetButtonDown("YButton"))
            {
                PlaySound(3);
            }
        }
    }

    public void PlaySound(int index)
    {
        if (index >= 0 && index < clips.Length)
            CmdSendServerSoundIndex(index);
    }

    [Command]
    void CmdSendServerSoundIndex(int index)
    {
        RpcSendSoundIndex(index);
    }

    [ClientRpc]
    void RpcSendSoundIndex(int index)
    {
        audiosource.PlayOneShot(clips[index]);
    }
}
