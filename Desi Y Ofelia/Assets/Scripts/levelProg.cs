using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
/*
  Attached to tracker object in Scene Hierarchy
  Is never destroyed tracks last and prev level. 
*/


public class levelProg : MonoBehaviour {
    string currentLevel;
    string lastlevel;
    GameObject Moon;
    GameObject Door1;
    GameObject Door2;
    GameObject Marigold1;
    GameObject Marigold2;

    // Prevents the tracker from being deleted.
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        //Tracks the current and laat level
        if (currentLevel != SceneManager.GetActiveScene().name)
        { 
            lastlevel = currentLevel;
        }

        currentLevel = SceneManager.GetActiveScene().name;

        Debug.Log("current: "+currentLevel);
        Debug.Log("last: " + lastlevel);

        //Checks to see if currently in the lobby.
        if (SceneManager.GetActiveScene().name == "Level Lobby")
        {
            Debug.Log("Currently in Lobby");
            lobbyLocks();
            lobbyEnd();
        }

    }


    /*
      After Player has finished all the levels the cover that blocks the
      staircase to moon is removed and the moon is lowered to act as the
      door to the exit. 
    */
    void lobbyEnd()
    {
        if (lastlevel == "Level 3")
        {
            Destroy(GameObject.Find("Cover"));
            Moon = GameObject.Find("Moon");
            Moon.transform.position = new Vector3(2.47f, 23.87f, 40.98f);
            
        }

    }

    //Opens levels based on whether or not player finished last level
    void lobbyLocks()
    {
        if(lastlevel == "Level 0")
        {
            Door1 = GameObject.Find("Door1");
            Door1.transform.position = new Vector3(12.21f, 4.55f, -24.85f);
            GameObject.Find("Marigold1").transform.position = new Vector3(10f, -0.8f, -22.1f);
            GameObject.Find("DoorRight1").transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x,
                                                                                transform.localRotation.eulerAngles.y-45,
                                                                                transform.localRotation.eulerAngles.z);

        if(lastlevel == "Level 1")
        {
            Door1 = GameObject.Find("Door1");
            Door1.transform.position = new Vector3(12.21f, 4.55f, -24.85f);
            Door2 = GameObject.Find("Door2");
            Door2.transform.position = new Vector3(-9.75f, 4.63f, -3.35f);

            GameObject.Find("Marigold1").transform.position = new Vector3(10f,-0.8f,-22.1f);
            GameObject.Find("Marigold2").transform.position = new Vector3(-6.4f,-0.8f,-3.7f);

           GameObject.Find("DoorRight2").transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x,
                                                                             transform.localRotation.eulerAngles.y - 45,
                                                                             transform.localRotation.eulerAngles.z);
            }

    }
}
