using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
   Cage Switch should be renamed
   Code Gets input from Ofelia Places corresponding letter to button. 

    Code Is attached to Ofelia.
    Current Max of code is 4 inputs. 

*/

public class cageSwitch : MonoBehaviour
{
    public string passCode;
    private Text text;
   
    void Start()
    {
        passCode = "";
        text = GameObject.Find("SwitchText").GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        text = GameObject.Find("SwitchText").GetComponent<Text>();
        text.text = passCode;

        if (Input.GetButtonDown("AButton"))
        {
            passCode += "K";
        }

        if (Input.GetButtonDown("BButton"))
        {
            passCode += "L";
        }

        if (Input.GetButtonDown("YButton"))
        {
            passCode += "I";
        }
        if (Input.GetButtonDown("XButton"))
        {
            
            passCode += "J";
        }

        if(passCode.Length > 4)
        {
            passCode = ""; 
        }
    }

}
