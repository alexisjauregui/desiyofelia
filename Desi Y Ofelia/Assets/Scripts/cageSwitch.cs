using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class cageSwitch : MonoBehaviour
{
 
    public string passCode;
    private Text text;


    void Start()
    {
        passCode = "";

        if (GameObject.Find("SwitchText").GetComponent<Text>())
        {
            Debug.Log("YoYOYO");
        }

        text = GameObject.Find("SwitchText").GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {

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

        if(passCode.Length == 5)
        {
            passCode = ""; 
        }
    }

}
