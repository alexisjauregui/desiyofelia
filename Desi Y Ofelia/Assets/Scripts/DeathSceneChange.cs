using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class DeathSceneChange : NetworkBehaviour {

    Text Timer;
	
	// Update is called once per frame
	void Update () {
        Timer = GameObject.Find("Timer").GetComponent<Text>();

        if (Timer.text == "0")
        {
            NetworkManager.singleton.ServerChangeScene("FailState");
        }

    }
}
