using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class Scene : MonoBehaviour {

    //public GameObject Desi;
    public GameObject Candle;
    public Transform Desi;
    private bool doorCollision0;
    private bool doorCollision1;
	private bool doorCollision2;
	private bool doorCollision3;
	private bool doorCollision4;
	private bool doorCollision5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (SceneManager.GetActiveScene().name == "Level 0")
        {
            //if (Desi.position.z <= -35 && Desi.position.x > -4.7 && Desi.position.x < 4.5 && HasCandle())
            if(HasCandle())
            {
                Debug.Log("You are holding a candle");
                if (doorCollision0)
                {
                    Debug.Log("Lobby Opened");
                    NetworkManager.singleton.ServerChangeScene("Level Lobby");
                }
            }
        }else if(SceneManager.GetActiveScene().name == "Level Lobby")
        {
            if (doorCollision0)
            {
                Debug.Log("Level 0 Opened");
                NetworkManager.singleton.ServerChangeScene("Level 0");
            }
            else if(doorCollision1)
            {
                Debug.Log("Level 1 Opened");
                NetworkManager.singleton.ServerChangeScene("Level 1");
            }
			else if (doorCollision2)
			{
				Debug.Log ("Level 2 Opened");
				//NetworkManager.singleton.ServerChangeScene("Level 2");
			}
			else if (doorCollision3)
			{
				Debug.Log ("Level 3 Opened");
				//NetworkManager.singleton.ServerChangeScene("Level 3");
			}
			else if (doorCollision4)
			{
				Debug.Log ("Level 4 Opened");
				//NetworkManager.singleton.ServerChangeScene("Level 4");
			}
			else if (doorCollision5)
			{
				Debug.Log ("Level 5 Opened");
				//NetworkManager.singleton.ServerChangeScene("Level 5");
			}
        }else if(SceneManager.GetActiveScene().name == "Level 1")
        {
            if (HasCandle())
            {
                Debug.Log("You are holding a candle");
                if (doorCollision1)
                {
                    Debug.Log("Lobby Opened");
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

    bool HasCandle()
    {
        if (GameObject.Find("CandleHolder(Clone)").transform.IsChildOf(transform))
            return true;
        return false;
    }
    

}
