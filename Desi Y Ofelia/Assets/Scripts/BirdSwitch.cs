using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class BirdSwitch : NetworkBehaviour {
    private GameObject Idol;
    public RaycastHit hit;
    public float distanceToSee;

    // Use this for initialization
    void Start ()
    {
        if(SceneManager.GetActiveScene().name == "Level 3")
        {
            distanceToSee = 2;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            if (seeingIdol())
            {
                if (Input.GetButtonDown("AButton"))
                {
                    Debug.Log("Got here Before!!!");
                    CmdTurnIdol();
                }
            }

        }
    }

    bool seeingIdol()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
        {
            if(hit.collider.name == "Idol(Clone)")
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


    void CmdTurnIdol()
    {
        Idol = GameObject.Find("Idol(Clone)");
        Idol.transform.Rotate(45, 0, 0);
    }

}
