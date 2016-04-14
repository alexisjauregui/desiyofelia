using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class healthbar : MonoBehaviour {

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
            Debug.Log(Mathf.Round(ini_health));

            rounded = Mathf.CeilToInt(ini_health);

            Timer.text = rounded.ToString();
            if(rounded < 0)
            {
                rounded = 0;
            }
            // If Zero End Game
            
        }
	
	}
}
