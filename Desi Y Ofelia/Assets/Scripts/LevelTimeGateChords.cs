using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class LevelTimeGateChords : NetworkBehaviour {

    private string chords;
    private Text newText;
    private GameObject cage;
    private GameObject gate;
    // Use this for initialization

    void Start () {
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = "";

            //gate = GameObject.FindGameObjectWithTag("Gate");  Need Gate Asset
            //gatebool = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = newText.text;

            cage = GameObject.FindGameObjectWithTag("Cage");
            gate = GameObject.FindGameObjectWithTag("Gate");

            if (chords.Contains("XBYX") && cage.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State")) //Can change chords to any combo
            {
                cage.GetComponent<Animator>().Play("TimeGateCage");
            }

            if (chords.Contains("BBAX") && gate.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State")) //Must add condition for Gate position vector
            {
                gate.GetComponent<Animator>().Play("TimeGate");
            }

        }
    }
}
