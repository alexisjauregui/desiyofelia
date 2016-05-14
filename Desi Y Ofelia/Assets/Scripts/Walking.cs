using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Walking : NetworkBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (isLocalPlayer)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetBool("Walk", true);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetBool("Walk", true);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetBool("Walk", true);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("Walk", true);
            }

            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("Walk", false);
            }
        }

	}
}
