using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class DesiScene : NetworkBehaviour {

    //public GameObject Desi;
    public GameObject Candle;
    public Transform Desi;
    [SerializeField] public bool doorCollision0;
    [SerializeField] private bool doorCollision1;
    [SerializeField] private bool doorCollision2;
    [SerializeField] private bool doorCollision3;
    [SerializeField] private bool doorCollision4;
    [SerializeField] private bool doorCollision5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (SceneManager.GetActiveScene().name == "Level 0")
        {
            GameObject.FindGameObjectWithTag("DesiWait").GetComponent<Text>().enabled = false;
            if (HasCandle())
            {
                GameObject.FindGameObjectWithTag("DesiWait").GetComponent<Text>().enabled = true;
                if (doorCollision0)
                {
                    Debug.Log("WAIT FOR YOUR PARTNER");
                    if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                        NetworkManager.singleton.ServerChangeScene("Level Lobby");
                }
            }
        }else if(SceneManager.GetActiveScene().name == "Level Lobby")
        {
            GameObject.FindGameObjectWithTag("DesiWait").GetComponent<Text>().enabled = false;
            if (doorCollision0)
            {
                GameObject.FindGameObjectWithTag("DesiWait").GetComponent<Text>().enabled = true;
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                    NetworkManager.singleton.ServerChangeScene("Level 0");
            }
            else if(doorCollision1)
            {
                GameObject.FindGameObjectWithTag("DesiWait").GetComponent<Text>().enabled = true;
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                    NetworkManager.singleton.ServerChangeScene("Level 1");
            }
			else if (doorCollision2)
			{
                Debug.Log("WAIT FOR YOUR PARTNER");
               // if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                //NetworkManager.singleton.ServerChangeScene("Level 2");
            }
			else if (doorCollision3)
			{
                Debug.Log("WAIT FOR YOUR PARTNER");
                //if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                //NetworkManager.singleton.ServerChangeScene("Level 3");
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
        }else if(SceneManager.GetActiveScene().name == "Level 1")
        {
            GameObject.FindGameObjectWithTag("DesiWait").GetComponent<Text>().enabled = false;
            if (HasCandle())
            {
                Debug.Log("You are holding a candle");
                if (doorCollision1)
                {
                    GameObject.FindGameObjectWithTag("DesiWait").GetComponent<Text>().enabled = false;
                    if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4)
                        NetworkManager.singleton.ServerChangeScene("Level Lobby");
                }
            }
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
