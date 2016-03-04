using UnityEngine;
using System.Collections;

public class BirdFlight : MonoBehaviour {
    private GameObject Idol;
    private GameObject Bird1;
    private GameObject Bird2;
    private GameObject Bird3;
    private GameObject Bird4;
    private Vector3 Pos2;



    // Use this for initialization
    void Start ()
    {
        Bird1 = GameObject.Find("Bird1");
        Bird2 = GameObject.Find("Bird2");
        Bird3 = GameObject.Find("Bird3");
        Bird4 = GameObject.Find("Bird4");
       


    }
	
	// Update is called once per frame
	void Update () {
        if(Idol = GameObject.Find("Idol(Clone)"))
        {
            if (Idol.transform.eulerAngles.y < 80)
            {
                Position1();
            }
            if (Idol.transform.eulerAngles.y > 80 && Idol.transform.eulerAngles.y < 95)
            {
                Position2();
            }
            if (Idol.transform.eulerAngles.y > 170 && Idol.transform.eulerAngles.y < 190)
            {
                Position3();
            }
           if(Idol.transform.eulerAngles.y == 270)
            {
                Position4();
            }
           
        }
	
	}

    void Position1()
    {
        Bird1.transform.position = new Vector3(-3, 3, -18);
        Bird2.transform.position = new Vector3(0, 3, -18);
        Bird3.transform.position = new Vector3(2, 3, -18);
        Bird4.transform.position = new Vector3(5, 3, -18);
    }
    void Position2()
    {
        Bird1.transform.position = new Vector3(-18, 3, 5);
        Bird2.transform.position = new Vector3(-18, 3, 2);
        Bird3.transform.position = new Vector3(-18, 3, 7);
        Bird4.transform.position = new Vector3(-18, 3, 1);

    }
    void Position3()
    {
        Bird1.transform.position = new Vector3(-4, 3, 18);
        Bird2.transform.position = new Vector3(0, 3, 18);
        Bird3.transform.position = new Vector3(2, 3, 18);
        Bird4.transform.position = new Vector3(5, 3, 18);
    }
    void Position4()
    {
        Bird1.transform.position = new Vector3(18, 3, 3);
        Bird2.transform.position = new Vector3(18, 3, 2);
        Bird3.transform.position = new Vector3(18, 3, 6);
        Bird4.transform.position = new Vector3(18, 3, 5);
    }
}
