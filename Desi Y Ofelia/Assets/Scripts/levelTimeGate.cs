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
    private GameObject gate;
    private bool gatebool;


    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = "";
            cage = GameObject.FindGameObjectWithTag("Cage");
            //gate = GameObject.FindGameObjectWithTag("Gate");  Need Gate Asset
            gatebool = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = newText.text;

            if (chords.Contains("ABXY") && cage.transform.position == new Vector3(15,1,-17)) //Can change chords to any combo
            {
                cage.GetComponent<Animation>().Play();
                gatebool = true;
            }

            if (chords.Contains("YAAX") ) //Must add condition for Gate position vector
            {
                //gate.GetComponent<Animation>().Play();
            }
        }
    }

   
}
