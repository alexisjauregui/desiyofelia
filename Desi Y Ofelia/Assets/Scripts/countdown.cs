using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
  Countdown 
  This code is for the UI in Ofelia when she is looking at Desi.
  Attached to the image on her Slider on her Canvas.   
*/

public class countdown : MonoBehaviour {

    public Image circularSilder;            
    public float time;                      
    public GameObject Ofelia;

    void Start()
    {
        circularSilder.fillAmount = 10f;      
    }
    void Update()
    {
        if (Ofelia.GetComponentInChildren<CanvasGroup>().alpha == 1)
        {
            circularSilder.fillAmount -= Time.deltaTime / time;
        }
    }
}
