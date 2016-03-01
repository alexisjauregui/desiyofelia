using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class level3Chords : NetworkBehaviour {
    private string pass;
    private string chords;
    private Text newText;
    private bool pass1;
    private bool pass2;
    private bool pass3;


    // Use this for initialization
    void Start () {
        if(SceneManager.GetActiveScene().name == "Level 3")
        {
            pass1 = false;
            pass2 = false;
            pass3 = false;
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = "";
        }
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = newText.text;

            if(chords == "AAAA")
            {
                pass1 = true;
            }
            if (chords == "BBBB")
            {
                pass2 = true;
            }
            if (chords == "XXXX")
            {
                pass3 = true;
            }

            if(pass1 && pass2 && pass3)
            {
                Debug.Log("Yass");
                CmdDestroy();
            }

        }

    }

    [Command]
    void CmdDestroy()
    {
        GameObject networkCage = GameObject.FindGameObjectWithTag("Cage");
        NetworkServer.Destroy(networkCage);
    }
}
