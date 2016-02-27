using UnityEngine;
using System.Collections;

public class cursor : MonoBehaviour {
    private RaycastHit hit;
    private float distance;

	// Use this for initialization
	void Start ()
    {
        distance = 2;
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distance))
        {
            if(hit.collider.gameObject.transform.GetChild(1).gameObject.tag == "Interact")
            {
                // Write switch canvas

            }
            
        }
    }
}
