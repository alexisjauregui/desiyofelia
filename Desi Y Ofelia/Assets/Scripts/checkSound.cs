using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(AudioSync))]
public class checkSound : NetworkBehaviour
{

    public AudioClip clipA;
    public AudioClip clipB;
    public AudioClip clipX;
    public AudioClip clipY;

    private AudioSource audioA;
    private AudioSource audioB;
    private AudioSource audioX;
    private AudioSource audioY;
    private AudioSync audiosyc;

    void Start()
    {
        audiosyc = this.GetComponent<AudioSync>();
    }

    public AudioSource AddAudio(AudioClip clip, bool playAwake)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = clip;
        newAudio.playOnAwake = playAwake;
        return newAudio;
    }

    void Awake()
    {
        audioA = AddAudio(clipA, false);
        audioB = AddAudio(clipB, false);
        audioX = AddAudio(clipX, false);
        audioY = AddAudio(clipY, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("AButton"))
        {
            audiosyc.PlaySound(audioA);
        }
        if (Input.GetButtonDown("BButton"))
        {
            audiosyc.PlaySound(audioB);
        }
        if (Input.GetButtonDown("XButton"))
        {
            audiosyc.PlaySound(audioX);
        }
        if (Input.GetButtonDown("YButton"))
        {
            audiosyc.PlaySound(audioY);
        }
    }
}
