using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LocalAuthority : NetworkBehaviour {



	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {
			GetComponentInChildren<Camera> ().enabled = true;
			GetComponent<CharacterController> ().enabled = true;
			GetComponent<OVRPlayerController> ().enabled = true;
		} else {
			GetComponentInChildren<Camera> ().enabled = false;
			GetComponent<CharacterController> ().enabled = false;
			GetComponent<OVRPlayerController> ().enabled = false;
		}
			
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
