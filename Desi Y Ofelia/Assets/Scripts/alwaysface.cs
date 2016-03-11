using UnityEngine;
using System.Collections;

public class alwaysface : MonoBehaviour {
    private Transform target;
    public Sprite image1;
    public Sprite image2;
    private GameObject Reticle;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Reticle == null)
        {
            Reticle = GameObject.Find("Retical");
        }

        if (GameObject.FindGameObjectWithTag("DesiPlayer"))
        {
            target = GameObject.FindGameObjectWithTag("DesiPlayer").transform;
        }
        if(target != null)
        {
            this.transform.LookAt(target);
        }
        //Change Picture
        if (GameObject.FindGameObjectWithTag("Cage"))
        {
            Reticle.GetComponent<SpriteRenderer>().sprite = image2;
        }
        else
        {
            Reticle.GetComponent<SpriteRenderer>().sprite = image1;
        }


        if(Vector3.Distance(target.position,this.transform.position)< 2)
        {
            Reticle.GetComponent<SpriteRenderer>().sprite = null;
        }
	}
}
