using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Scene : MonoBehaviour {

    //public GameObject Desi;
    public GameObject Candle;
    public Transform Desi;
    private Vector3 curr_position;

	// Use this for initialization
	void Start () {
        curr_position = Desi.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (SceneManager.GetActiveScene().name == "Level 0")
        {
            if (Desi.position.z <= -35 && Desi.position.x > -4.7 && Desi.position.x < 4.5 && HasCandle())
            {
                Debug.Log("Lobby Opened");
                SceneManager.LoadScene("Level Lobby");
                //SceneManager.MoveGameObjectToScene(Desi, Level Lobby);
            }
        }else if(SceneManager.GetActiveScene().name == "Level Lobby")
        {
            if (Desi.position.x <= -8 && Desi.position.z > 34.4 && Desi.position.z < 38)
            {
                Debug.Log("Level 0 Opened");
                SceneManager.LoadScene("Level 0");
                //SceneManager.MoveGameObjectToScene(Desi, Level 0);
            }
            else if(Desi.position.x >= 10.25 && Desi.position.z > 48.64 && Desi.position.z < 53.85)
            {
                Debug.Log("Level 1 Opened");
                SceneManager.LoadScene("Level 1");
                //SceneManager.MoveGameObjectToScene(Desi, Level 1);
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
			if (Desi.position.x >= 1.11 && Desi.position.z > -2.29 && Desi.position.z < 4.38 && HasCandle())
            {
                Debug.Log("Lobby Opened");
                SceneManager.LoadScene("Level Lobby");
                //SceneManager.MoveGameObjectToScene(Desi, Level Lobby);
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

    bool HasCandle()
    {
        if (GameObject.FindGameObjectWithTag("Candle").transform.IsChildOf(transform))
            return true;
        return false;
    }
    

}
