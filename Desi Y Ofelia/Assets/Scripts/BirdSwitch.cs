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
				if (GetComponentInParent<NetworkIdentity>().isLocalPlayer) 
				{
					if (Input.GetButtonDown ("AButton")) 
					{
						CmdTurnIdol ();
					}
				}
            }

        }
    }

    bool seeingIdol()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
        {
            Debug.Log(hit);
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
        //Debug.Log(Idol.transform.eulerAngles.y);

        Idol.transform.eulerAngles = new Vector3(Idol.transform.eulerAngles.x, Idol.transform.eulerAngles.y+90, Idol.transform.eulerAngles.z);
        Idol.GetComponent<AudioSource>().Play();

    }

}
