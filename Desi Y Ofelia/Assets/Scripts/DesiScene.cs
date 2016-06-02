using UnityEngine;
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
	private bool ready;
    private bool ready0;
	private bool ready1;
	private bool ready3;
	private bool ready4;
	private bool readyf;
    //public GameObject spawn;
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
		ready = false;
		ready0 = false;
		ready1 = false;
		ready3 = false;
		ready4 = false;
		readyf = false;
    }

    void OnLevelWasLoaded(int level)
    {
		ready = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (SceneManager.GetActiveScene ().name == "Level 0") {
			//ready = false;
			if (HasCandle ()) {
				if (doorCollision0) {
					if (IsClose ()) {
						if (!ready) {
							GetComponentInChildren<OVRScreenFadeOut> ().Fade ("Level Lobby");
							ready = true;
						}
					}
				}
			}
		} else if (SceneManager.GetActiveScene ().name == "Level Lobby") {
			if (doorCollision0) {
				if (IsClose ()) {
					if (!ready0) {
						GetComponentInChildren<OVRScreenFadeOut> ().Fade ("Level 0");
						ready0 = true;
					}
				}
			}
			if (doorCollision1) {
				if (IsClose ()) {
					//spawn.transform.position = new Vector3(9, 1, -22);
					if (!ready1) {
						GetComponentInChildren<OVRScreenFadeOut> ().Fade ("Level 1");
						ready1 = true;
					}
				}
			}
			if (doorCollision2) {
				if (IsClose ()) {
					//spawn.transform.position = new Vector3(-5, 1, -4);
					if (!ready3) {
						GetComponentInChildren<OVRScreenFadeOut> ().Fade ("Level 3");
						ready3 = true;
					}
				}
			}
			if (doorCollision3) {
				Debug.Log ("WAIT FOR YOUR PARTNER Final");
				if (IsClose ()) {
					if (!readyf) {
						GetComponentInChildren<OVRScreenFadeOut> ().Fade ("Final");
						readyf = true;
					}
				}
			} else if (doorCollision4) {
				Debug.Log ("WAIT FOR YOUR PARTNER");
				// if (IsClose())
				//NetworkManager.singleton.ServerChangeScene("Level 4");
			} else if (doorCollision5) {
				Debug.Log ("WAIT FOR YOUR PARTNER");
				//if (IsClose())
				//NetworkManager.singleton.ServerChangeScene("Level 5");
			}
		} else if (SceneManager.GetActiveScene ().name == "Level 1") {
			if (HasCandle ()) {
				if (doorCollision1) {
					if (IsClose ()) {

						NetworkManager.singleton.ServerChangeScene ("Level Lobby");
					}
				}
			}
		} else if (SceneManager.GetActiveScene ().name == "Level 3") 
		{
			if (HasCandle ())
			{
				if (doorCollision2) 
				{
					if (IsClose ()) 
					{
						NetworkManager.singleton.ServerChangeScene ("Level Lobby");
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

    public bool HasCandle()
    {
        if (GameObject.Find("CandleHolder(Clone)").transform.IsChildOf(transform))
            return true;
        return false;
    }

    public bool IsClose()
    {
        return (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("OfeliaPlayer").transform.position) < 4);
    }

}