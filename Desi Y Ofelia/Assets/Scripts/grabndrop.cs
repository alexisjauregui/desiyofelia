﻿using UnityEngine;
using System.Collections;

public class grabndrop : MonoBehaviour {

    private GameObject Candle;
    public RaycastHit hit;
    public float distanceToSee;
    private Vector3 dropLoc;

    


    void Start()
    {
        Candle = GameObject.Find("CandleHolder");

    }

    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.red);

        dropLoc = Candle.transform.position; 

        if (Candle.transform.IsChildOf(transform))
        {
            Candle.GetComponent<CapsuleCollider>().enabled = false;

            if (Input.GetButtonDown("AButton"))
            {
                Candle.transform.parent = null;
                Candle.transform.position = new Vector3(dropLoc.x,0.75f,dropLoc.z);
                Candle.transform.rotation = new Quaternion(0, 0, 0, 0);
                Candle.GetComponent<CapsuleCollider>().enabled = true;
            }
        }
        else
        {

            if (checkIfForward())
            {
                Debug.Log("Yes");
                if (Input.GetButtonDown("AButton"))
                {

                   
                    Candle.transform.parent = transform;
                }
            }
        }
    }

    bool checkIfForward()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee)){

            if (hit.collider.name == "CandleHolder")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

}
