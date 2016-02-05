using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class cageSwitch : MonoBehaviour
{

    private string passCode;
    private GameObject Cage;
    private Text text;
    AudioSource audio;
    bool hasPlayed = false;

    void Start()
    {
        passCode = "";
        audio = GetComponent<AudioSource>();
        Cage = GameObject.Find("Cage");
        text = GameObject.Find("SwitchText").GetComponent<Text>();
        
        
    }


    // Update is called once per frame
    void Update()
    {

        text.text = passCode;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            passCode += "Z";
            Debug.Log(passCode.Length);

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            passCode += "C";
        }
        //Code for activation 
        if (passCode == "CZCZ")
        {
            Destroy(Cage, 0);
            if (hasPlayed == false)
            {
                hasPlayed = true;
                audio.Play();
            }
            
        }

        if (passCode.Length == 5)
        {
            passCode = "";
        }

    }

}
