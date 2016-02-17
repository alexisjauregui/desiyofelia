using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class checkSound3 : MonoBehaviour
{
    //[HideInInspector]
    public string passCode;
    private Text text;
    public AudioSource audio;


    void Start()
    {
        passCode = "";
        text = GameObject.Find("SwitchText").GetComponent<Text>();
        audio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {

        text.text = passCode;

        if (Input.GetButtonDown("XButton"))
        {
            passCode += "J";
            audio.Play();
        }
    }
}
