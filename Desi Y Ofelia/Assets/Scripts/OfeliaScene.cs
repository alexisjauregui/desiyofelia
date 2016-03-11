using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class OfeliaScene : NetworkBehaviour {

    //public GameObject Desi;
    public GameObject Candle;
    public Text text;
    [SerializeField] public bool doorCollision0;
    [SerializeField] private bool doorCollision1;
    [SerializeField] private bool doorCollision2;
    [SerializeField] private bool doorCollision3;
    [SerializeField] private bool doorCollision4;
    [SerializeField] private bool doorCollision5;

    // Use this for initialization
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("OfeliaWait").GetComponent<Text>();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        text.enabled = false;
        if (SceneManager.GetActiveScene().name == "Level 0")
        {
            if (GameObject.FindGameObjectWithTag("DesiPlayer").GetComponent<DesiScene>().HasCandle())
            {
                if (doorCollision0)
                {
                    text.enabled = true;
                    if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("DesiPlayer").transform.position) < 4)
                    {
                        text.enabled = false;
                        CmdSceneChange("Level Lobby");
                    }
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level Lobby")
        {
            if (doorCollision0)
            {
                text.enabled = true;
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("DesiPlayer").transform.position) < 4)
                {
                    text.enabled = false;
                    CmdSceneChange("Level 0");
                }
            }
            else if (doorCollision1)
            {
                text.enabled = true;
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("DesiPlayer").transform.position) < 4)
                {
                    text.enabled = false;
                    CmdSceneChange("Level 1");
                }
            }
            else if (doorCollision2)
            {
                Debug.Log("WAIT FOR YOUR PARTNER");
                //NetworkManager.singleton.ServerChangeScene("Level 2");
            }
            else if (doorCollision3)
            {
                Debug.Log("WAIT FOR YOUR PARTNER");
                //NetworkManager.singleton.ServerChangeScene("Level 3");
            }
            else if (doorCollision4)
            {
                Debug.Log("WAIT FOR YOUR PARTNER");
                //NetworkManager.singleton.ServerChangeScene("Level 4");
            }
            else if (doorCollision5)
            {
                Debug.Log("WAIT FOR YOUR PARTNER"); 
                //NetworkManager.singleton.ServerChangeScene("Level 5");
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level 1")
        {
            if (GameObject.FindGameObjectWithTag("DesiPlayer").GetComponent<DesiScene>().HasCandle())
            {
                if (doorCollision1)
                {
                    text.enabled = true;
                    if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("DesiPlayer").transform.position) < 4)
                    {
                        text.enabled = false;
                        NetworkManager.singleton.ServerChangeScene("Level Lobby");
                    }
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

	[ServerCallback]
	void CmdSceneChange(string level)
	{
		NetworkManager.singleton.ServerChangeScene(level);
	}



}




