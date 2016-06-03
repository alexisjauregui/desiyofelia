using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class Restart : NetworkBehaviour {
    Text newText;
    bool reset = false;
    int check;


	// Update is called once per frame
	void Update () {
        newText = this.GetComponent<Text>();

        if (Input.GetButtonDown("AButton") && !reset)
        {
            newText.text = "Try Again?";
            reset = true;
            check = 0;
            
        }

        if (reset)
        {
            if (Input.GetButtonDown("AButton") && check > 50)
            {
                string level = GameObject.Find("Tracker").GetComponent<levelProg>().lastlevel;
                NetworkManager.singleton.ServerChangeScene(level);
                //CmdSceneChange("StartMenu");
            }
            if (Input.GetButtonDown("BButton"))
            {
                NetworkManager.singleton.ServerChangeScene("StartMenu");
                //CmdSceneChange("StartMenu");
            }

            check++;
        }
	}

    [ServerCallback]
    void CmdSceneChange(string level)
    {
        NetworkManager.singleton.ServerChangeScene(level);
    }

}
