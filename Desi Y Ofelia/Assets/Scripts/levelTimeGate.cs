using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class levelTimeGate : NetworkBehaviour
{

    private string pass;
    private string chords;
    private Text newText;
    private GameObject cage;
    private GameObject gate;
    private GameObject Switch;
    private bool gatebool;
    public float distanceToSee;
    public RaycastHit hit;



    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = "";
            cage = GameObject.FindGameObjectWithTag("Cage");
            //gate = GameObject.FindGameObjectWithTag("Gate");  Need Gate Asset
            gatebool = false;
        }
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            distanceToSee = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            newText = GameObject.FindGameObjectWithTag("Switch").GetComponent<Text>();
            chords = newText.text;

            if (chords.Contains("ABXY") && cage.transform.position == new Vector3(15, 1, -17)) //Can change chords to any combo
            {
                cage.GetComponent<Animation>().Play();
                gatebool = true;
            }

            if (chords.Contains("YAAX")) //Must add condition for Gate position vector
            {
                //gate.GetComponent<Animation>().Play();
            }

            if (seeingCageSwitch())
            {
                if (isLocalPlayer)
                {
                    if (Input.GetButtonDown("AButton"))
                    {
                        GameObject CageSwitch = GameObject.Find("CageSwitch");
                        CageSwitch.GetComponent<Animator>().Play("TimeGateCageSwitch");
                    }
                }
            }

            if (seeingDoorSwitch())
            {
                Debug.Log("lever");
                if (isLocalPlayer)
                {
                    if (Input.GetButtonDown("AButton"))
                    {
                        GameObject entrance = GameObject.Find("Entrance");
                        GameObject DoorSwitch = GameObject.Find("DoorSwitch");
                        DoorSwitch.GetComponent<Animator>().Play("TimeGateDoorSwitch");
                        entrance.GetComponent<Animator>().Play("TimeGateEntrance");
                    }
                }
            }
        }

    }

    bool seeingCageSwitch()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
        {
            Debug.Log(hit);
            if (hit.collider.name == "CageSwitch")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    bool seeingDoorSwitch()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
        {
            Debug.Log(hit);
            if (hit.collider.name == "DoorSwitch")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    [Command]
    void CmdTurnCageSwitch()
    {
        Switch = GameObject.Find("CageSwitch(Clone)");
        

        //transform switch

    }

    [Command]
    void CmdTurnDoorSwitch()
    {
        Switch = GameObject.Find("DoorSwitch(Clone)");

        //transform switch
    }
}