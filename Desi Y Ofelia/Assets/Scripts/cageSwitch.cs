using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class cageSwitch : MonoBehaviour
{

    private string passCode;
    public GameObject Cage;
    public Text text;
    AudioSource audio;
    bool hasPlayed = false;

    void Start()
    {
        passCode = "";
        audio = GetComponent<AudioSource>();
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

        if (Input.GetKeyDown(KeyCode.X))
        {
            passCode += "X";
        }
        //Code for activation 
        if (passCode == "XZXZ")
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
