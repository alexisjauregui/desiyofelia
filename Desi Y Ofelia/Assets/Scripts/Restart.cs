using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class Restart : NetworkBehaviour {
    Text newText;
    bool reset = false;


	// Update is called once per frame
	void Update () {
        newText = this.GetComponent<Text>();

        if (Input.GetButtonDown("AButton") && !reset)
        {
            newText.text = "Try Again?";
            reset = true;
        }

        if (reset)
        {
            if (Input.GetButtonDown("AButton"))
            {
                Debug.Log("A is pressed");
                NetworkManager.singleton.ServerChangeScene("StartMenu");
                //CmdSceneChange("StartMenu");
            }
        }
	}

    [ServerCallback]
    void CmdSceneChange(string level)
    {
        NetworkManager.singleton.ServerChangeScene(level);
    }

}
