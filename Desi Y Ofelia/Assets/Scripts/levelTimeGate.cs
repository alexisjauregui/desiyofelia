using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class levelTimeGate : NetworkBehaviour {

    private string pass;
    private string chords;
    private Text newText;
    private GameObject cage;


    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = newText.text;

            if (chords.Contains("ABXY"))
            {
                newText.text = "";
                chords = newText.text;
                CmdCageMove();
                
            }
        }
    }

    [Command]
    void CmdCageMove()
    {
        cage = GameObject.FindGameObjectWithTag("Cage");
        Vector3 pos = new Vector3(15, 7, -17);
        cage.transform.position = pos;
    }
}
