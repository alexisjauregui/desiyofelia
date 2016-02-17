using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (SceneManager.GetActiveScene().name != "Level lobby")
        {
            Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.red);
            PickUp = GameObject.FindGameObjectWithTag("Pickup");
            if (PickUp != null)
            {
                dropLoc = PickUp.transform.position;
            }

            if (PickUp.transform.IsChildOf(transform))
            {

                PickUp.GetComponent<BoxCollider>().enabled = false;
                PickUp.transform.rotation = new Quaternion(0, 0, 0, 0);

                if (Input.GetButtonDown("AButton"))
                {
                    PickUp.transform.parent = null;
                    PickUp.transform.position = new Vector3(dropLoc.x, 0.376f, dropLoc.z);
                    if(SceneManager.GetActiveScene().name == "Level 1")
                        PickUp.transform.position = new Vector3(dropLoc.x, -1.2f, dropLoc.z);
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
