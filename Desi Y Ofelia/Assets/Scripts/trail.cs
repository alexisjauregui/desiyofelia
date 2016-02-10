using UnityEngine;
using System.Collections;

public class trail : MonoBehaviour {

    public Object flower;
    public Transform Desi;

    private Vector3 lastPosition;
    private Vector3 currentPosition;
    private Quaternion Rot;

    void Start()
    {
        currentPosition = Desi.position;
        Rot = new Quaternion(0, 0, 0,0);
    }

	
	// Update is called once per frame
	void Update (){

        if (Mathf.Abs(currentPosition.x - Desi.position.x) > 1 || Mathf.Abs(currentPosition.z - Desi.position.z) > 1)
        {
            currentPosition.y = 0;
            Instantiate(flower,currentPosition,Rot);
            
            currentPosition = Desi.position;
           
        }      

	}


}
