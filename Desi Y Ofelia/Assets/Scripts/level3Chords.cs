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
    private bool pass4;

    private ParticleSystem particleA;
    private ParticleSystem particleB;
    private ParticleSystem particleC;
    private ParticleSystem particleD;

    private GameObject towerG;
    private GameObject towerR;
    private GameObject towerY;
    private GameObject towerB;

    private GameObject Green;
    private GameObject Red;
    private GameObject Orange;
    private GameObject Blue;

    

    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            pass1 = false;
            pass2 = false;
            pass3 = false;
            pass4 = false;
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = "";

            particleA = GameObject.Find("greenRain").GetComponent<ParticleSystem>();
            particleA.Pause();
            particleB = GameObject.Find("redRain").GetComponent<ParticleSystem>();
            particleB.Pause();
            particleC = GameObject.Find("yellowRain").GetComponent<ParticleSystem>();
            particleC.Pause();
            particleD = GameObject.Find("blueRain").GetComponent<ParticleSystem>();
            particleD.Pause();

            towerG = GameObject.Find("indicatorG");
            towerR = GameObject.Find("indicatorR");
            towerY = GameObject.Find("indicatorY");
            towerB = GameObject.Find("indicatorB");

            Green = GameObject.Find("Green Banners");
            Red = GameObject.Find("Red Banners");
            Orange = GameObject.Find("Orange Banners");
            Blue = GameObject.Find("Blue Banners");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = newText.text;

            if (chords.Contains("BABX"))
            {
                pass1 = true;
                particleA.Play();
                CmdIndicatorMove(0);
                CmdBannerChange(0);
            }
            if (chords.Contains("ABXY"))
            {
                pass2 = true;
                particleB.Play();
                CmdIndicatorMove(1);
                CmdBannerChange(1);
            }
            if (chords.Contains("AYBA"))
            {
                pass3 = true;
                particleC.Play();
                CmdIndicatorMove(2);
                CmdBannerChange(2);

            }
            if (chords.Contains("YAXY"))
            {
                pass4 = true;
                particleD.Play();
                CmdIndicatorMove(3);
                CmdBannerChange(3);
            }
            if (pass1 && pass2 && pass3 && pass4)
            {
                CmdDestroy();
                pass1 = pass2 = pass3 = pass4 = false;
            }

        }

    }

    [Command]
    void CmdDestroy()
    {
        GameObject networkCage = GameObject.FindGameObjectWithTag("Cage");
        NetworkServer.Destroy(networkCage);
    }

   
    void CmdIndicatorMove(int color)
    {
        if(color == 0)
            towerG.transform.position = new Vector3(0, -2, 0);
        else if(color == 1)
            towerR.transform.position = new Vector3(0, -2, 0);
        else if(color == 2)
            towerY.transform.position = new Vector3(0, -2, 0);
        else
            towerB.transform.position = new Vector3(0, -2, 0);

    }

   
    void CmdBannerChange(int color)
    {
        if (color == 0)
        {
            Green.SetActive(false);
        }
        else if (color == 1)
        {
            Red.SetActive(false);
        }
        else if (color == 2)
        {
            Orange.SetActive(false);
        }
        else
        {
            Blue.SetActive(false);
        }
    }
}
