using UnityEngine;
using System.Collections;

public class trailer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButton("XButton"))
        {
            GameObject leftdoor = GameObject.Find("halfdoor2");
            leftdoor.GetComponent<Animator>().Play("LeftDoor");
            GameObject rightdoor = GameObject.Find("halfdoor");
            rightdoor.GetComponent<Animator>().Play("Rightdoor");
        }
	}
}
