using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;

public class healthbar : NetworkBehaviour {

	private float ini_health = 10;
    private int decrimant = 1;
    private int rounded;
    public GameObject Ofelia;
    private Text Timer;
    
	
	// Update is called once per frame
	void Update () {

        Timer = GameObject.Find("Timer").GetComponent<Text>();

        if (Ofelia.GetComponentInChildren<CanvasGroup>().alpha == 1)
        {
            ini_health -= Time.deltaTime * decrimant;
            //Debug.Log(Mathf.Round(ini_health));

            rounded = Mathf.CeilToInt(ini_health);

            if (rounded < 0)
            {
                rounded = 0;
               
            }

            Timer.text = rounded.ToString();
                        
        }
	
	}
}
