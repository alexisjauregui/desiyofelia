﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class checkSound3 : MonoBehaviour
{
   
    public AudioSource audio;


    void Start()
    {
        
        audio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("XButton"))
        {

            audio.Play();
        }
    }
}
