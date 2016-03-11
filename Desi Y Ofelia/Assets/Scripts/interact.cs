using UnityEngine;
using System.Collections;

public class interact : MonoBehaviour {

    // Use this for initialization
    private Transform target;
    private GameObject Reticle;
    public Sprite image1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Reticle == null)
        {
            Reticle = GameObject.Find("KeyRetical");
        }

        if (GameObject.FindGameObjectWithTag("DesiPlayer"))
        {
            target = GameObject.FindGameObjectWithTag("DesiPlayer").transform;
        }
        if (target != null)
        {
            this.transform.LookAt(target);
        }
        //Change Picture
        if (Vector3.Distance(target.position, this.transform.position) < 2)
        {
            Reticle.GetComponent<SpriteRenderer>().sprite = null;
        }
        if (Vector3.Distance(target.position, this.transform.position) > 2.1)
        {
            Reticle.GetComponent<SpriteRenderer>().sprite = image1;
        }
        
    }
}
