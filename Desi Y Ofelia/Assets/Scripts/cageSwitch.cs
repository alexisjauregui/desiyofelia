using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

/*
   Cage Switch should be renamed
   Code Gets input from Ofelia Places corresponding letter to button. 

    Code Is attached to Ofelia.
    Current Max of code is 4 inputs. 

*/

public class cageSwitch : NetworkBehaviour
{
    private string passCode;
    private Text text;

    //Ripple Effect
    public Object RippleA;
    public Object RippleB;
    public Object RippleX;
    public Object RippleY;
    public Transform Ofelia;
    private Vector3 currentPosition;
    private Quaternion Rot;
    private float startTime;
    private float elapseTime; 


    void Start()
    {
        passCode = "";
        text = GameObject.Find("SwitchText").GetComponent<Text>();

        // Ripple Effect
		currentPosition = Ofelia.position;
        Rot = new Quaternion(0, 90, 90, 0);

        //timed Reset
        startTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        text = GameObject.Find("SwitchText").GetComponent<Text>();
        text.text = passCode;

        //Ripple 
        currentPosition = Ofelia.position;
        currentPosition.y = 0.1f;

        
        

        elapseTime = Time.time - startTime;

        if(elapseTime > 2)
        {
            passCode = "";
        }

        if(isLocalPlayer)
        {
            if (Input.GetButtonDown("AButton"))
            {
                passCode += "A";
                Instantiate(RippleA, currentPosition, Rot);
                startTime = Time.time;
            }

            if (Input.GetButtonDown("BButton"))
            {
                passCode += "B";
                Instantiate(RippleB, currentPosition, Rot);
                startTime = Time.time;
            }

            if (Input.GetButtonDown("YButton"))
            {
                passCode += "Y";
                Instantiate(RippleY, currentPosition, Rot);
                startTime = Time.time;
            }
            if (Input.GetButtonDown("XButton"))
            {

                passCode += "X";
                Instantiate(RippleX, currentPosition, Rot);
                startTime = Time.time;
            }
        }

        // if (SceneManager.GetActiveScene().name == "Level 0")
        /* {
             if (passCode.Length > 4)
             {
                 passCode = "";
             }
      */
    }
}


