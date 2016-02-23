using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class grabndrop : NetworkBehaviour
{

    private GameObject PickUp;
    public RaycastHit hit;
    public float distanceToSee;
    private Vector3 dropLoc;




    void Start()
    {
        PickUp = GameObject.FindGameObjectWithTag("Pickup");
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Level lobby")
        {
            Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.red);
            PickUp = GameObject.FindGameObjectWithTag("Pickup");
            Debug.Log(PickUp.name);
            if (PickUp != null)
            {
                dropLoc = PickUp.transform.position;
            }

            if (HasCandle())
            {
                PickUp.GetComponent<BoxCollider>().enabled = false;
                PickUp.transform.rotation = new Quaternion(0, 0, 0, 0);

                if (Input.GetButtonDown("AButton"))
                {
                    CmdDrop();
                }
            }
            /*if (HasKey())
            {
                PickUp.GetComponent<BoxCollider>().enabled = false;
                PickUp.transform.rotation = new Quaternion(0, 0, 0, 0);

                if (Input.GetButtonDown("AButton"))
                {
                    CmdDrop();
                }
            }*/
            else
            {

                if (checkIfForward())
                {
                    Debug.Log("Yes");
                    PickUp = hit.collider.gameObject;
                    if (Input.GetButtonDown("AButton"))
                    {
                        CmdPickup();
                    }
                }
            }
        }
        Debug.Log(HasCandle());
    }


    bool checkIfForward()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
        {

            if (hit.collider.tag == "Pickup")
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    bool HasCandle()
    {
        if (GameObject.Find("CandleHolder(Clone)").transform.IsChildOf(transform))
            return true;
        return false;
    }

    bool HasKey()
    {
        if (GameObject.Find("Key").transform.IsChildOf(transform))
            return true;
        return false;
    }

    //[Command]
    void CmdPickup()
    {
        PickUp.transform.parent = transform;
    }

    //[Command]
    void CmdDrop()
    {   
        PickUp.transform.parent = null;
        PickUp.transform.position = new Vector3(dropLoc.x, 0.376f, dropLoc.z);
        PickUp.transform.rotation = new Quaternion(0, 0, 0, 0);
        PickUp.GetComponent<BoxCollider>().enabled = true;
    }
}
