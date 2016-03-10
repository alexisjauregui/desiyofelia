using UnityEngine;
using System.Collections;

public class alwaysface : MonoBehaviour {
    private Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.FindGameObjectWithTag("DesiPlayer"))
        {
            target = GameObject.FindGameObjectWithTag("DesiPlayer").transform;
        }
        if(target != null)
        {
            this.transform.LookAt(target);
        }
        //Debug.Log(target.name);
	}
}
