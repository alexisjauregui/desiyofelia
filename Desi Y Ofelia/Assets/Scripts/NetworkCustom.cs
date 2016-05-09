﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

[AddComponentMenu("Network/NetworkManagerHUD")]
[RequireComponent(typeof(NetworkManager))]
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public class NetworkCustom : MonoBehaviour {

    public NetworkManager manager;
	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                manager.StartServer();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                manager.StartHost();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                manager.StartClient();
            }
            manager.networkAddress = GameObject.Find("InputField").GetComponent<InputField>().text;
        }
        if (NetworkServer.active && NetworkClient.active)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                manager.StopHost();
            }
        }

    }

    public void Host()
    {
        GetComponent<NetManagerCustom>().playerPrefabIndex = 0;
        manager.StartHost(); 
    }

    public void Join()
    {
        GetComponent<NetManagerCustom>().playerPrefabIndex = 1;
        manager.StartClient();
    }
}
