using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class bgchange : MonoBehaviour, ISelectHandler {

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
    }
}
