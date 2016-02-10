using UnityEngine;
using System.Collections;

public class trailDestroy : MonoBehaviour {
    private GameObject Desi;
    private Vector3 dPos;

    void Start()
    {
        Desi = GameObject.FindGameObjectWithTag("Test");
    }

	// Update is called once per frame
	void Update () {
        Desi = GameObject.FindGameObjectWithTag("Test");
        dPos = Desi.transform.position;
        Debug.Log(Vector3.Distance(dPos, transform.position));
       

        
        if (Vector3.Distance(dPos, transform.position) > 7)
        {
            Destroy(Desi.gameObject);
        }
	
	}
}
