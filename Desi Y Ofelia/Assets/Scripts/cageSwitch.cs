using UnityEngine;
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
            passCode += "A";
        }

        if (Input.GetButtonDown("BButton"))
        {
            passCode += "B";
        }

        if (Input.GetButtonDown("YButton"))
        {
            passCode += "Y";
        }
        if (Input.GetButtonDown("XButton"))
        {
            
            passCode += "X";
        }

       // if (SceneManager.GetActiveScene().name == "Level 0")
       // {
            if (passCode.Length > 4)
            {
                passCode = "";
            }
       // }
    }

}
