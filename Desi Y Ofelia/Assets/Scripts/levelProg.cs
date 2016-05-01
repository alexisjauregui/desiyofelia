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
        if (level3)
        {
            Destroy(GameObject.Find("Cover"));
        }

    }
}
