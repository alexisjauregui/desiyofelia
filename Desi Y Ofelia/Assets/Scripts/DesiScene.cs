﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class DesiScene : NetworkBehaviour
{

    //public GameObject Desi;
    public GameObject Candle;
    public Text Sign0;
    public Text Sign1;
    public Text Sign2;
    public Text Sign3;
    public Text Sign4;
    [SerializeField]
    public bool doorCollision0;
    [SerializeField]
    private bool doorCollision1;
    [SerializeField]
    private bool doorCollision2;
    [SerializeField]
    private bool doorCollision3;
    [SerializeField]
    private bool doorCollision4;
    [SerializeField]
    private bool doorCollision5;

    // Use this for initialization
    void Start()
    {
        Sign0 = GameObject.Find("Sign0").GetComponent<Text>();
        Sign0.enabled = false;
        Sign1 = GameObject.Find("Sign1").GetComponent<Text>();
        Sign1.enabled = false;
        Sign2 = GameObject.Find("Sign2").GetComponent<Text>();
        Sign2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "Level 0")
        {
            if (HasCandle())
            {
                if (doorCollision0)
                {
                    Sign0.enabled = true;
                    if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                    {
                        Sign0.enabled = false;
                        NetworkManager.singleton.ServerChangeScene("Level Lobby");
                    }
                }
                else
                {
                    Sign0.enabled = false;
                }
            }
            else
                Sign0.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "Level Lobby")
        {
            if (doorCollision0)
            {
                Sign0.enabled = true;
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                {
                    Sign0.enabled = false;
                    NetworkManager.singleton.ServerChangeScene("Level 0");
                }
            }
            else
            {
                Sign0.enabled = false;
            }
            if (doorCollision1)
            {
                Sign1.enabled = true;
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                {
                    Sign1.enabled = false;
                    NetworkManager.singleton.ServerChangeScene("Level 1");
                }
            }
            else
            {
                Sign1.enabled = false;
            }
            if (doorCollision2)
            {
                Sign2.enabled = true;
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                {
                    Sign2.enabled = false;
                    NetworkManager.singleton.ServerChangeScene("Level 3");
                }
            }
            else
            {
                Sign2.enabled = false;
            } 
            if (doorCollision3)
            {
                Debug.Log("WAIT FOR YOUR PARTNER Final");
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                NetworkManager.singleton.ServerChangeScene("Final");
            }
            else if (doorCollision4)
            {
                Debug.Log("WAIT FOR YOUR PARTNER");
                // if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                //NetworkManager.singleton.ServerChangeScene("Level 4");
            }
            else if (doorCollision5)
            {
                Debug.Log("WAIT FOR YOUR PARTNER");
                //if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                //NetworkManager.singleton.ServerChangeScene("Level 5");
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level 1")
        {
            if (HasCandle())
            {
                Debug.Log("You are holding a candle");
                if (doorCollision1)
                {
                    Sign1.enabled = true;
                    if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                    {
                        Sign1.enabled = false;
                        NetworkManager.singleton.ServerChangeScene("Level Lobby");
                    }
                }
                else
                {
                    Sign1.enabled = false;
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            Sign2 = GameObject.Find("Sign2").GetComponent<Text>();
            if (HasCandle())
            {
                if (doorCollision2)
                {
                    Sign2.enabled = true;
                    if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                    {
                        Sign2.enabled = false;
                        NetworkManager.singleton.ServerChangeScene("Level Lobby");
                    }
                }
                else
                {
                    Sign2.enabled = false;
                }
            }
            else
                Sign2.enabled = false;
        }

    }

    void OnTriggerEnter(Collider door)
    {
        if (door.gameObject.tag == "Door0")
            doorCollision0 = true;
        if (door.gameObject.tag == "Door1")
            doorCollision1 = true;
        if (door.gameObject.tag == "Door2")
            doorCollision2 = true;
        if (door.gameObject.tag == "Door3")
            doorCollision3 = true;
        if (door.gameObject.tag == "Door4")
            doorCollision4 = true;
        if (door.gameObject.tag == "Door5")
            doorCollision5 = true;
    }

    void OnTriggerExit(Collider door)
    {
        if (door.gameObject.tag == "Door0")
            doorCollision0 = false;
        if (door.gameObject.tag == "Door1")
            doorCollision1 = false;
        if (door.gameObject.tag == "Door2")
            doorCollision2 = false;
        if (door.gameObject.tag == "Door3")
            doorCollision3 = false;
        if (door.gameObject.tag == "Door4")
            doorCollision4 = false;
        if (door.gameObject.tag == "Door5")
            doorCollision5 = false;
    }

    public bool HasCandle()
    {
        if (GameObject.Find("CandleHolder(Clone)").transform.IsChildOf(transform))
            return true;
        return false;
    }


}