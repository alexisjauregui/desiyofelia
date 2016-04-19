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

    private ParticleSystem particleA;
    private ParticleSystem particleB;
    private ParticleSystem particleC;

    private GameObject towerG;
    private GameObject towerR;
    private GameObject towerY;
    private GameObject towerB;

    // Use this for initialization
    void Start () {
        if(SceneManager.GetActiveScene().name == "Level 3")
        {
            pass1 = false;
            pass2 = false;
            pass3 = false;
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = "";

            particleA = GameObject.Find("greenRain").GetComponent<ParticleSystem>();
            particleA.Pause();
            particleB = GameObject.Find("redRain").GetComponent<ParticleSystem>();
            particleB.Pause();
            particleC = GameObject.Find("yellowRain").GetComponent<ParticleSystem>();
            particleC.Pause();

            towerG = GameObject.Find("indicatorG");
            towerR = GameObject.Find("indicatorR");
            towerY = GameObject.Find("indicatorY");
            towerB = GameObject.Find("indicatorB");
        }
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = newText.text;

            if(chords.Contains("BABX"))
            {
                pass1 = true;
                particleA.Play();
                towerG.transform.position = new Vector3(0, -2, 0);
                GameObject.Find("green").GetComponent<Renderer>().material.color = Color.white;
            }
            if (chords.Contains("ABXY"))
            {
                pass2 = true;
                particleB.Play();
                towerR.transform.position = new Vector3(0, -2, 0);
                GameObject.Find("red").GetComponent<Renderer>().material.color = Color.white;
            }
            if (chords.Contains("AYBA"))
            {
                pass3 = true;
                particleC.Play();
                towerY.transform.position = new Vector3(0, -2, 0);
                GameObject.Find("yellow").GetComponent<Renderer>().material.color = Color.white;
            }

            if(pass1 && pass2 && pass3)
            {
                Debug.Log("Yass");
                CmdDestroy();
                towerB.transform.position = new Vector3(0, -2, 0);
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
