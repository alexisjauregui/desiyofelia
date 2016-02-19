using UnityEngine;
using UnityEngine.Networking; 
using System.Collections;

public class openDoor : NetworkBehaviour {

    private GameObject Desi;
    private GameObject Key;

	void Start()
    {
        Desi = GameObject.FindGameObjectWithTag("DesiPos");
        Key = GameObject.Find("Key");
    }
	
	// Update is called once per frame
	void Update ()
	{
        Desi = GameObject.FindGameObjectWithTag("DesiPos");

        if (Vector3.Distance(this.transform.position, Desi.transform.position)<5)
        {
            
            if (GameObject.Find("Key").transform.IsChildOf(Desi.transform))
            {
				CmdDestroyDoor ();    
            }
        }
	}

	[Command]
	void CmdDestroyDoor()
	{
		Destroy (GameObject.Find ("ClosetDoor"));
		Key.transform.parent = null;
		Destroy (Key);
	}


}
