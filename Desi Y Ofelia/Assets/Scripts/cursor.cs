using UnityEngine;
using System.Collections;

public class cursor : MonoBehaviour {
    private RaycastHit hit;
    private float distance;
    private GameObject crosshair;
    public Texture image1;
    public Texture image2;
    

	// Use this for initialization
	void Start ()
    {
        distance = 2;
        crosshair = GameObject.Find("Crosshair");

	}

    // Update is called once per frame
    void Update()
    {
        crosshair.GetComponent<Renderer>().material.mainTexture = image1;

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distance))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.gameObject.transform.childCount > 0)
            {
                if (hit.collider.gameObject.transform.GetChild(0).gameObject.tag == "Interact")
                {
                    crosshair.GetComponent<Renderer>().material.mainTexture = image2;
                }
      
               
           
            }
           
          
        }


       
    }


}
