using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class countdown : MonoBehaviour {

    public Image circularSilder;            //Drag the circular image i.e Slider in our case
    public float time;                      //In how much time the progress bar will fill/empty
    public GameObject Ofelia;

    void Start()
    {
        circularSilder.fillAmount = 10f;      // Initally progress bar is empty
    }
    void Update()
    {
        if (Ofelia.GetComponentInChildren<CanvasGroup>().alpha == 1)
        {
            circularSilder.fillAmount -= Time.deltaTime / time;
        }
    }
}
