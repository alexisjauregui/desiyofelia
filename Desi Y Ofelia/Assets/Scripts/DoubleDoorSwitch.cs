using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoubleDoorSwitch : NetworkBehaviour {
    private GameObject doorSwitch;
    private GameObject door1;
    private GameObject door2;
    public RaycastHit hit;
    public float distanceToSee;

    // Use this for initialization
    void Start () {
	    if (SceneManager.GetActiveScene().name == "Level 4")
        {
            distanceToSee = 2;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (SceneManager.GetActiveScene().name == "Level 4")
        {
            if (seeingSwitch())
            {
                if (Input.GetButtonDown("AButton"))
                    CmdDoorSwitch();
            }
        }
	}

    bool seeingSwitch()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
        {
            if (hit.collider.name == "doorSwitch(Clone)")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    [Command]
    void CmdDoorSwitch()
    {
        doorSwitch = GameObject.Find("DoubleDoorSwitch");

        //Do switch animation here

        door1 = GameObject.Find("door1");
        door2 = GameObject.Find("door2");

        //if (door1 is open and door2 is closed)
        //{ 
        //      close door1 and open door2
        //}
        //vice versa    

    }
}
