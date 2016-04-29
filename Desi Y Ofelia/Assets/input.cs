using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class input : MonoBehaviour {

	// Use this for initialization
	void Start () {
            
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            InputField input = this.GetComponent<InputField>();
            input.ActivateInputField();
            input.Select();
        }
        if (Input.GetKeyDown("space"))
        {
            InputField input = this.GetComponent<InputField>();
            input.ActivateInputField();
            input.Select();
        }
    }
}
