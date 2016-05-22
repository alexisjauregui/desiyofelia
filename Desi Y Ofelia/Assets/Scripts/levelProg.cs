using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class levelProg : MonoBehaviour {
    bool level0;
    bool level1;
    bool level2;
    bool level3 = false;
    string currentLevel;
    string lastlevel;
    GameObject Moon;
    //GameObject MoonHall;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel != SceneManager.GetActiveScene().name)
        { 
            lastlevel = currentLevel;
        }

        currentLevel = SceneManager.GetActiveScene().name;

        Debug.Log("current: "+currentLevel);
        Debug.Log("last: " + lastlevel);


        if (SceneManager.GetActiveScene().name == "Level Lobby")
        {
            Debug.Log("Currently in Lobby");
            lobbyProg();
        }
	
	}

    void lobbyProg()
    {
        if (lastlevel == "Level 3")
        {
            Destroy(GameObject.Find("Cover"));
            Moon = GameObject.Find("Moon");
            MoonHall = GameObject.Find("MoonHall");
            Moon.transform.position = new Vector3(2.47f, 23.87f, 40.98f);
            //MoonHall.transform.position = new Vector3(2.66f, 23.606f, 141.074f);
        }

    }
}
