using UnityEngine;
using System.Collections;

public class BirdFlight : MonoBehaviour
{
    private GameObject Idol;
    private GameObject Bird1;
    private GameObject Bird2;
    private GameObject Bird3;
    private GameObject Bird4;
    private Vector3 Pos2;
    private Vector3 rot;



    // Use this for initialization
    void Start()
    {
        Bird1 = GameObject.Find("Bird1");
        Bird2 = GameObject.Find("Bird2");
        Bird3 = GameObject.Find("Bird3");
        Bird4 = GameObject.Find("Bird4");

        rot = new Vector3(Bird1.transform.eulerAngles.x, Bird1.transform.eulerAngles.y, Bird1.transform.eulerAngles.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (Idol = GameObject.Find("Idol(Clone)"))
        {
            if (Idol.transform.eulerAngles.y < 80)
            {
                Position4();
                Debug.Log("4");
            }
            if (Idol.transform.eulerAngles.y > 80 && Idol.transform.eulerAngles.y < 95)
            {
                Position1();
                Debug.Log("1");
            }
            if (Idol.transform.eulerAngles.y > 170 && Idol.transform.eulerAngles.y < 190)
            {
                Position2();
                Debug.Log("2");
            }
            if (Idol.transform.eulerAngles.y == 270)
            {
                Position3();
                Debug.Log("3");
            }

        }

    }

    void Position1()
    {
        Bird1.transform.position = new Vector3(1.8f, 6.25f, -29.5f);
        Bird2.transform.position = new Vector3(-5.75f, 6.25f, -29.5f);
        Bird3.transform.position = new Vector3(-7.75f, 6.25f, -29.5f);
        Bird4.transform.position = new Vector3(-3, 6.25f, -29.5f);

        Vector3 rot4 = new Vector3(rot.x, rot.y + 90, rot.z);

        Bird1.transform.eulerAngles = rot4;
        Bird2.transform.eulerAngles = rot4;
        Bird3.transform.eulerAngles = rot4;
        Bird4.transform.eulerAngles = rot4;

    }
    void Position2()
    {
        Bird1.transform.position = new Vector3(-30, 6.25f, -7.5f);
        Bird2.transform.position = new Vector3(-30, 6.25f, 0);
        Bird3.transform.position = new Vector3(-30, 6.25f, 2);
        Bird4.transform.position = new Vector3(-30, 6.25f, 7);

        Vector3 rot2 = new Vector3(rot.x, rot.y + 180, rot.z);

        Bird1.transform.eulerAngles = rot2;
        Bird2.transform.eulerAngles = rot2;
        Bird3.transform.eulerAngles = rot2;
        Bird4.transform.eulerAngles = rot2;
    }
    void Position3()
    {
        Bird1.transform.position = new Vector3(-8, 6.25f, 29);
        Bird2.transform.position = new Vector3(6.75f, 6.25f, 29);
        Bird3.transform.position = new Vector3(-1.1f, 6.25f, 29);
        Bird4.transform.position = new Vector3(-5.5f, 6.25f, 29);

        Vector3 rot3 = new Vector3(rot.x, rot.y + 270, rot.z);

        Bird1.transform.eulerAngles = rot3;
        Bird2.transform.eulerAngles = rot3;
        Bird3.transform.eulerAngles = rot3;
        Bird4.transform.eulerAngles = rot3;
    }
    void Position4()
    {
        Bird1.transform.position = new Vector3(30f, 6.25f, 5.25f);
        Bird2.transform.position = new Vector3(30f, 6.25f, -2.3f);
        Bird3.transform.position = new Vector3(30f, 6.25f, -4.3f);
        Bird4.transform.position = new Vector3(30f, 6.25f, 0.6f);



        Bird1.transform.eulerAngles = rot;
        Bird2.transform.eulerAngles = rot;
        Bird3.transform.eulerAngles = rot;
        Bird4.transform.eulerAngles = rot;
    }
}