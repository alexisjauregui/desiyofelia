﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/*
   Cage Switch should be renamed
   Code Gets input from Ofelia Places corresponding letter to button. 

    Code Is attached to Ofelia.
    Current Max of code is 4 inputs. 

*/

public class cageSwitch : MonoBehaviour
{
    private string passCode;
    private Text text;

    //Ripple Effect
    public GameObject RippleA;
    public GameObject RippleB;
    public GameObject RippleX;
    public GameObject RippleY;
    public Transform Ofelia;
    private Vector3 currentPosition;
    private Quaternion Rot;


    void Start()
    {
        passCode = "";
        text = GameObject.Find("SwitchText").GetComponent<Text>();

        // Ripple Effect
        currentPosition = Ofelia.position;
        Rot = new Quaternion(0, 90, 90, 0);
    }


    // Update is called once per frame
    void Update()
    {
        text = GameObject.Find("SwitchText").GetComponent<Text>();
        text.text = passCode;

        //Ripple 
        currentPosition = Ofelia.position;
        currentPosition.y = 1.0f;


        if (Input.GetButtonDown("AButton"))
        {
            passCode += "A";
            Instantiate(RippleA, currentPosition, Rot);
        }

        if (Input.GetButtonDown("BButton"))
        {
            passCode += "B";
            Instantiate(RippleB, currentPosition, Rot);
        }

        if (Input.GetButtonDown("YButton"))
        {
            passCode += "Y";
            Instantiate(RippleY, currentPosition, Rot);
        }
        if (Input.GetButtonDown("XButton"))
        {
            
            passCode += "X";
            Instantiate(RippleX, currentPosition, Rot);
        }

       /* if (SceneManager.GetActiveScene().name == "Level 0")
       // {
            if (passCode.Length > 4)
            {
                passCode = "";
            }
       */ }
    }


