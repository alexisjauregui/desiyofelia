using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {

    private GameObject Desi;
    private Vector3 dPos;

	void Start()
    {
        Desi = GameObject.FindGameObjectWithTag("Desi");
       
    }
	
	// Update is called once per frame
	void Update () {

        Desi = GameObject.FindGameObjectWithTag("Desi");
        dPos = Desi.transform.position;
        

        if (Vector3.Distance(transform.position, Desi.transform.position)<5)
        {
            
            if (GameObject.Find("Key").transform.IsChildOf(Desi.transform))
            {
                Destroy(GameObject.Find("ClosetDoor"));
                Destroy(GameObject.Find("Key")); 
            }
        }
        


	}
}
