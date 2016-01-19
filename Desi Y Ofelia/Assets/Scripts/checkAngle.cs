using UnityEngine;
using System.Collections;

public class checkAngle : MonoBehaviour {

    public float fieldOV = 110f;
    public bool playerIS;
    private GameObject Cube;
    

	// Update is called once per frame
	void Update () {

	
	}

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject == Cube)
        {

        }
    }
}
