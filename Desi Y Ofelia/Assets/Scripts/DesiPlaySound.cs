using UnityEngine;
using System.Collections;

public class DesiPlaySound : MonoBehaviour {

    private AudioSource audiosource;
    public AudioClip[] clips;

    // Use this for initialization
    void Start()
    {
        audiosource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
