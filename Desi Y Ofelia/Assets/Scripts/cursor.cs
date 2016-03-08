using UnityEngine;
using System.Collections;

public class cursor : MonoBehaviour {
    private RaycastHit hit;
    private float distance;
    private GameObject crosshair;
    public Texture image1;
    public Texture image2;
    private float scale;
    

	// Use this for initialization
	void Start ()
    {
        distance = 15;
        crosshair = GameObject.Find("Crosshair");

	}

    // Update is called once per frame
    void Update()
    {
        crosshair.GetComponent<Renderer>().material.mainTexture = image1;

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distance))
        {
            //Debug.Log(hit.collider.name);
            if (hit.collider.gameObject.transform.childCount > 0)
            {
                if (hit.collider.gameObject.transform.GetChild(0).gameObject.tag == "Interact")
                {
                    Debug.Log(Vector3.Distance(transform.position,hit.collider.transform.position));
                    crosshair.GetComponent<Renderer>().material.mainTexture = image2;
                    crosshair.transform.localScale = new Vector3( xScale(Vector3.Distance(transform.position, hit.collider.transform.position)), xScale(Vector3.Distance(transform.position, hit.collider.transform.position)), 0);


                }
      
               
           
            }
           
          
        }       
    }

    float xScale(float distance)
    {
        Debug.Log(distance);
        scale = (distance / 20);
        scale = scale * .48f;
        scale += 0.025f;
        scale = 1 - scale;
        scale -= 0.6f;
        return scale;
    }

}
