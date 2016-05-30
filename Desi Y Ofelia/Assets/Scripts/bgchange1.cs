﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class bgchange1 : MonoBehaviour, ISelectHandler, IDeselectHandler {

    public Texture skullbg;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("YButton"))
        {
            Button button = this.GetComponent<Button>();
            button.Select();
        }
	}

    public void OnSelect(BaseEventData eventData)
    {
        GameObject bg = GameObject.Find("bg");
        bg.GetComponent<RawImage>().texture = skullbg;
        this.GetComponent<Image>().color = Color.white;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        this.GetComponent<Image>().color = Color.black;
    }
}
