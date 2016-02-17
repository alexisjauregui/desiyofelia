using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {

    private GameObject Desi;
    private GameObject Key;

	void Start()
    {
        Desi = GameObject.FindGameObjectWithTag("Desi");
        Key = GameObject.Find("Key");
    }
	
	// Update is called once per frame
	void Update () {

        Desi = GameObject.FindGameObjectWithTag("Desi");

        

        if (Vector3.Distance(transform.position, Desi.transform.position)<5)
        {
            
            if (GameObject.Find("Key").transform.IsChildOf(Desi.transform))
            {
                Destroy(GameObject.Find("ClosetDoor"));
                Key.transform.parent = null;
                Destroy(Key); 
            }
        }
        


	}
}
