using UnityEngine;
using System.Collections;

public class OfeliaPlaySound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("AButton"))
        {
            GetComponent<checkSound>().PlaySound(0);
        }
        if (Input.GetButtonDown("BButton"))
        {
            GetComponent<checkSound>().PlaySound(1);
        }
        if (Input.GetButtonDown("XButton"))
        {
            GetComponent<checkSound>().PlaySound(2);
        }
        if (Input.GetButtonDown("YButton"))
        {
            GetComponent<checkSound>().PlaySound(3);
        }
    }
}
