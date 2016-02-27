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
            if(PickUp == null)
                PickUp = GameObject.FindGameObjectWithTag("Pickup");
            Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.red);
            if (PickUp != null)
            {
                dropLoc = PickUp.transform.position;
            }

            if (HasItem())
            {
                PickUp.GetComponent<BoxCollider>().enabled = false;
                PickUp.transform.rotation = new Quaternion(0, 0, 0, 0);

                if (Input.GetButtonDown("AButton"))
                {
                    CmdDrop();
                }
            }
            else
            {

                if (checkIfForward())
                {
                    PickUp = hit.collider.gameObject;
                    if (Input.GetButtonDown("AButton"))
                    {
                        CmdPickup();
                    }
                }
            }
        }
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

    bool HasItem()
    {
        if (PickUp.transform.parent == transform && PickUp != null)
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
