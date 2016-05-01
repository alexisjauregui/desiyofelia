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
                particleA = GameObject.Find("greenRain").GetComponent<ParticleSystem>();
                particleA.Play();
                CmdIndicatorMove(0);
                CmdBannerChange(0);
            }
            if (chords.Contains("ABXY"))
            {
                pass2 = true;

                particleB = GameObject.Find("redRain").GetComponent<ParticleSystem>();
                particleB.Play();
                CmdIndicatorMove(1);
                CmdBannerChange(1);
            }
            if (chords.Contains("AYBA"))
            {
                pass3 = true;
                particleC = GameObject.Find("yellowRain").GetComponent<ParticleSystem>();
                particleC.Play();
                CmdIndicatorMove(2);
                CmdBannerChange(2);

            }
            if (chords.Contains("YAXY"))
            {
                pass4 = true;
                particleD = GameObject.Find("blueRain").GetComponent<ParticleSystem>();
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

   [Command]
    void CmdIndicatorMove(int color)
    {
        if (color == 0)
        {
			GameObject towerG = GameObject.Find("indicatorG(Clone)");
			NetworkServer.Destroy (towerG);
        }
        else if (color == 1)
        {
			GameObject towerR = GameObject.Find("indicatorR(Clone)");
			NetworkServer.Destroy (towerR);
        }
        else if (color == 2)
        {
			GameObject towerY = GameObject.Find("indicatorY(Clone)");
			NetworkServer.Destroy (towerY);
        }
        else
        {
			GameObject towerB = GameObject.Find("indicatorB(Clone)");
			NetworkServer.Destroy (towerB);
        }
    }

   [Command]
    void CmdBannerChange(int color)
    {
        if (color == 0)
        {
			GameObject Green = GameObject.Find("Green Banners(Clone)");
			NetworkServer.Destroy (Green);
        }
        else if (color == 1)
        {
			GameObject Red = GameObject.Find("Red Banners(Clone)");
			NetworkServer.Destroy (Red);
        }
        else if (color == 2)
        {
			GameObject Orange = GameObject.Find("Orange Banners(Clone)");
			NetworkServer.Destroy (Orange);
        }
        else
        {
			GameObject Blue = GameObject.Find("Blue Banners(Clone)");
			NetworkServer.Destroy (Blue);
        }
    }
}
