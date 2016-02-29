using UnityEngine;
using System.Collections;

public class BirdFlight : MonoBehaviour {
    private GameObject Idol;
    private GameObject Bird1;
    private GameObject Bird2;
    private GameObject Bird3;
    private GameObject Bird4;



    // Use this for initialization
    void Start ()
    {
        Bird1 = GameObject.Find("Bird1");
        Bird1 = GameObject.Find("Bird2");
        Bird1 = GameObject.Find("Bird3");
        Bird1 = GameObject.Find("Bird4");


    }
	
	// Update is called once per frame
	void Update () {
        if(Idol = GameObject.Find("Idol(Clone)"))
        {
            Debug.Log(Idol.transform.rotation);
           
        }
	
	}
}
