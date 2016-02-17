using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class Scene : MonoBehaviour {

    //public GameObject Desi;
    public GameObject Candle;
    public Transform Desi;
    private Vector3 curr_position;
    private bool doorCollision0;
    private bool doorCollision1;

	// Use this for initialization
	void Start () {
        curr_position = Desi.position;
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
			else if (Desi.position.x <= -8 && Desi.position.z > 75 && Desi.position.z < 80)
			{
				Debug.Log ("Level 2 Opened");
				//SceneManager.LoadScene ("Level 2");
				//SceneManager.MoveGameObjectToScene(Desi_obj, "Level 2");
			}
			else if (Desi.position.x >= 10 && Desi.position.z > 97 && Desi.position.z < 103)
			{
				Debug.Log ("Level 3 Opened");
				//SceneManager.LoadScene ("Level 3");
				//SceneManager.MoveGameObjectToScene(Desi_obj, "Level 3");
			}
			else if (Desi.position.z <= -8 && Desi.position.z > 120 && Desi.position.z < 125)
			{
				Debug.Log ("Level 4 Opened");
				//SceneManager.LoadScene ("Level 4");
				//SceneManager.MoveGameObjectToScene(Desi_obj, "Level 4");
			}
			else if (Desi.position.x >= 10 && Desi.position.z > 157 && Desi.position.z < 162)
			{
				Debug.Log ("Level 5 Opened");
				//SceneManager.LoadScene ("Level 5");
				//SceneManager.MoveGameObjectToScene(Desi_obj, "Level 5");
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
        }/*else if(SceneManager.GetActiveScene().name == "Level 2")
		{
			if (Desi.position.x >= 1.11 && Desi.position.z > -2.29 && Desi.position.z < 4.38 && HasCandle())
			{
				Debug.Log("Lobby Opened");
				SceneManager.LoadScene("Level Lobby");
				//SceneManager.MoveGameObjectToScene(Desi, Level Lobby);
			}
		}else if(SceneManager.GetActiveScene().name == "Level 3")
		{
			if (Desi.position.x >= 1.11 && Desi.position.z > -2.29 && Desi.position.z < 4.38 && HasCandle())
			{
				Debug.Log("Lobby Opened");
				SceneManager.LoadScene("Level Lobby");
				//SceneManager.MoveGameObjectToScene(Desi, Level Lobby);
			}
		}else if(SceneManager.GetActiveScene().name == "Level 4")
		{
			if (Desi.position.x >= 1.11 && Desi.position.z > -2.29 && Desi.position.z < 4.38 && HasCandle())
			{
				Debug.Log("Lobby Opened");
				SceneManager.LoadScene("Level Lobby");
				//SceneManager.MoveGameObjectToScene(Desi, Level Lobby);
			}
		}else if(SceneManager.GetActiveScene().name == "Level 5")
		{
			if (Desi.position.x >= 1.11 && Desi.position.z > -2.29 && Desi.position.z < 4.38 && HasCandle())
			{
				Debug.Log("Lobby Opened");
				SceneManager.LoadScene("Level Lobby");
				//SceneManager.MoveGameObjectToScene(Desi, Level Lobby);
			}
		}*/

    }

    void OnTriggerEnter(Collider door)
    {
        if (door.gameObject.tag == "Door0")
            doorCollision0 = true;
        if (door.gameObject.tag == "Door1")
            doorCollision1 = true; 
    }

    void OnTriggerExit(Collider door)
    {
        if (door.gameObject.tag == "Door0")
            doorCollision0 = false;
        if (door.gameObject.tag == "Door1")
            doorCollision1 = false;
    }

    bool HasCandle()
    {
        if (GameObject.Find("CandleHolder").transform.IsChildOf(transform))
            return true;
        return false;
    }
    

}
