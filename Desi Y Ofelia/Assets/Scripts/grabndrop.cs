using UnityEngine;
using System.Collections;

public class grabndrop : MonoBehaviour {

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
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.red);

        dropLoc = PickUp.transform.position; 

        if (PickUp.transform.IsChildOf(transform))
        {
 
            PickUp.GetComponent<BoxCollider>().enabled = false;
            PickUp.transform.rotation = new Quaternion(0, 0, 0, 0);

            if (Input.GetButtonDown("AButton"))
            {
                PickUp.transform.parent = null;
                PickUp.transform.position = new Vector3(dropLoc.x,0.376f,dropLoc.z);
                PickUp.transform.rotation = new Quaternion(0, 0, 0, 0);
                PickUp.GetComponent<BoxCollider>().enabled = true;
            }
        }
        else
        {

            if (checkIfForward())
            {
                Debug.Log("Yes");
                PickUp = hit.collider.gameObject;
                if (Input.GetButtonDown("AButton"))
                {

                   
                    PickUp.transform.parent = transform;
                }
            }
        }
    }

    bool checkIfForward()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee)){

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

}
