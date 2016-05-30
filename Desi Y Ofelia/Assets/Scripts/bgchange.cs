using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class bgchange : MonoBehaviour, ISelectHandler, IDeselectHandler {

    public Texture desibg;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnSelect(BaseEventData eventData)
    {
        GameObject bg = GameObject.Find("bg");
        bg.GetComponent<RawImage>().texture = desibg;
        this.GetComponent<Image>().color = Color.white;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        this.GetComponent<Image>().color = Color.black;
    }
}
