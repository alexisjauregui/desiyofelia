using UnityEngine;
using System.Collections;

public class vision : MonoBehaviour {

    // Use this for initialization
    RaycastHit Hit1;
    public float distanceToSee;
    //public Text text;
    private Vector3 Left;
    private Vector3 Right;
    private Vector3 Bottom;
    private Vector3 Top;



    void Start()
    {
        //text.text = "    ";


    }
    void Update()
    {

        //Debug.Log(this.transform.forward.x);

        Left = new Vector3(this.transform.forward.x - 0.7f, this.transform.forward.y, this.transform.forward.z);
        Right = new Vector3(this.transform.forward.x + 0.7f, this.transform.forward.y, this.transform.forward.z);
        Bottom = new Vector3(this.transform.forward.x - 0.7f, this.transform.forward.y - 0.1f, this.transform.forward.z);
        Top = new Vector3(this.transform.forward.x + offset(), this.transform.forward.y + 0.1f, this.transform.forward.z);

        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.red);
        Debug.DrawRay(this.transform.position, Left * distanceToSee, Color.blue);
        Debug.DrawRay(this.transform.position, Right * distanceToSee, Color.cyan);
        Debug.DrawRay(this.transform.position, Bottom * distanceToSee, Color.green);
        Debug.DrawRay(this.transform.position, Top * distanceToSee, Color.magenta);


        if (checkHit())
        {
            if (Hit1.collider.name == "Desi")
            {
                Debug.Log("Currently Hitting: " + Hit1.collider.name);
               // text.text = "You \n Lose";
            }
        }
        else
        {
            //text.text = "   ";
        }

    }


    bool checkHit()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out Hit1, distanceToSee)
           || (Physics.Raycast(this.transform.position, Left, out Hit1, distanceToSee)))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    float offset()
    {
        if (this.transform.rotation.z > 90)
        {
            return 0.7f;
        }
        else
        {
            return 0.7f;
        }
    }
}
