using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class ObjectSpawn : NetworkBehaviour {

    public GameObject cage;
    public GameObject candle;
    public GameObject idol;

    // Use this for initialization

    void Start () {
        CmdcageSpawn(cage.transform.position, cage.transform.rotation);
        CmdcandleSpawn(candle.transform.position, candle.transform.rotation);
        CmdIdolSpawn(idol.transform.position, idol.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    [Command]
    void CmdcageSpawn(Vector3 pos, Quaternion rot)
    {
        if (SceneManager.GetActiveScene().name == "Level 0")
        {
            GameObject spawnNetworkCage = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/cage"), pos, rot);
            NetworkServer.Spawn(spawnNetworkCage);
            Debug.Log("Cage spawned");
        }
        else if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Vector3 newpos = new Vector3(-5, 1.1f, 4.5f);
            GameObject spawnNetworkCage = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/cage"), newpos, rot);
            NetworkServer.Spawn(spawnNetworkCage);
            Debug.Log("Cage spawned");
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            Vector3 newpos = new Vector3(-5, 1.1f, 4.5f);
            GameObject spawnNetworkCage = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/cage"), newpos, rot);
            NetworkServer.Spawn(spawnNetworkCage);
            Debug.Log("Cage spawned");
        }

    }

    [Command]
    void CmdcandleSpawn(Vector3 pos, Quaternion rot)
    {
        if (SceneManager.GetActiveScene().name == "Level 0")
        {
            GameObject spawnNetworkcandle = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CandleHolder"), pos, rot);
            NetworkServer.Spawn(spawnNetworkcandle);
            Debug.Log("Candle spawned");
        }
        else if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Vector3 newpos = new Vector3(-5, 0.4f, 4.5f);
            GameObject spawnNetworkcandle = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CandleHolder"), newpos, rot);
            NetworkServer.Spawn(spawnNetworkcandle);
            Debug.Log("Candle spawned");
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            Vector3 newpos = new Vector3(-5, 0.4f, 4.5f);
            GameObject spawnNetworkcandle = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CandleHolder"), newpos, rot);
            NetworkServer.Spawn(spawnNetworkcandle);
            Debug.Log("Candle spawned");
        }
    }

    [Command]
    void CmdIdolSpawn(Vector3 pos, Quaternion rot)
    {
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            GameObject spawnNetworkidol = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Idol"), pos, rot);
            NetworkServer.Spawn(spawnNetworkidol);
            Debug.Log("Idol spawned");
        }

    }
}
