using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;


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

    void Start()
    {

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

        }
        if (Input.GetButtonDown("BButton"))
        {

        }
        if (Input.GetButtonDown("XButton"))
        {

        }
        if (Input.GetButtonDown("YButton"))
        {

        }
    }
}
