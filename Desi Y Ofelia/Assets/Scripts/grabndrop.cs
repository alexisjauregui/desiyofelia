using UnityEngine;
using System.Collections;

public class grabndrop : MonoBehaviour {

    private GameObject Candle;
    public RaycastHit hit;
    public float distanceToSee;

    


    void Start()
    {
        Candle = GameObject.Find("CandleHolder");

    }

    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.red);

        if (Candle.transform.IsChildOf(transform))
        {
            Candle.GetComponent<CapsuleCollider>().enabled = false;

            if (Input.GetButtonDown("AButton"))
            {
                Candle.transform.parent = null;
                Candle.GetComponent<CapsuleCollider>().enabled = true;
            }
        }
        else
        {

            if (checkIfForward())
            {
                Debug.Log("Yes");
                if (Input.GetButtonDown("AButton"))
                {

                   
                    Candle.transform.parent = transform;
                }
            }
        }
    }

    bool checkIfForward()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee)){

            if (hit.collider.name == "CandleHolder")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

}
