using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class checkSound1 : MonoBehaviour
{
    
    public AudioSource audio;


    void Start()
    {
        
        audio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {

     

        if (Input.GetButtonDown("BButton"))
        {
         
            audio.Play();
        }
    }
}
