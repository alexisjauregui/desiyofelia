using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class cageSwitch : MonoBehaviour {

    private string passCode;
    public GameObject Cage;
    public Text text;
	
    void Start()
    {
        passCode = "";
       
    }


	// Update is called once per frame
	void Update () {

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

        if(passCode == "XZXZ")
        {
            Destroy(Cage, 0);
        }

        if( passCode.Length == 5)
        {
            passCode = "";
        }

	}
}
