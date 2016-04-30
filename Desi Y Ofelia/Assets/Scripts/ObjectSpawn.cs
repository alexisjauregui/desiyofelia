using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class ObjectSpawn : NetworkBehaviour {

    public GameObject cage;
    public GameObject candle;
    public GameObject idol;
    public GameObject[] indicator;
    public GameObject[] banner;


    // Use this for initialization

    void Start () {
        CmdcageSpawn(cage.transform.position, cage.transform.rotation);
        CmdcandleSpawn(candle.transform.position, candle.transform.rotation);
        CmdIdolSpawn(idol.transform.position, idol.transform.rotation);
        CmdIndiSpawn(indicator[0].transform.position, indicator[0].transform.rotation,
                     indicator[1].transform.position, indicator[1].transform.rotation,
                     indicator[2].transform.position, indicator[2].transform.rotation,
                     indicator[3].transform.position, indicator[3].transform.rotation);
        CmdbannerSpawn(banner[0].transform.position, banner[0].transform.rotation,
                     banner[1].transform.position, banner[1].transform.rotation,
                     banner[2].transform.position, banner[2].transform.rotation,
                     banner[3].transform.position, banner[3].transform.rotation);
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
        }
        else if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Vector3 newpos = new Vector3(25, 0.7f, 19f);
            GameObject spawnNetworkCage = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/cage"), newpos, rot);
            NetworkServer.Spawn(spawnNetworkCage);
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            Vector3 newpos = new Vector3(-25, 1f, 25f);
            GameObject spawnNetworkCage = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/cage"), newpos, rot);
            NetworkServer.Spawn(spawnNetworkCage);
        }

    }

    [Command]
    void CmdcandleSpawn(Vector3 pos, Quaternion rot)
    {
        if (SceneManager.GetActiveScene().name == "Level 0")
        {
            GameObject spawnNetworkcandle = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CandleHolder"), pos, rot);
            NetworkServer.Spawn(spawnNetworkcandle);
        }
        else if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Vector3 newpos = new Vector3(25, 0.5f, 19f);
            GameObject spawnNetworkcandle = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CandleHolder"), newpos, rot);
            NetworkServer.Spawn(spawnNetworkcandle);
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            Vector3 newpos = new Vector3(-25, 0.7f, 25f);
            GameObject spawnNetworkcandle = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CandleHolder"), newpos, rot);
            NetworkServer.Spawn(spawnNetworkcandle);

        }
    }

    [Command]
    void CmdIdolSpawn(Vector3 pos, Quaternion rot)
    {
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            GameObject spawnNetworkidol = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Idol"), pos, rot);
            NetworkServer.Spawn(spawnNetworkidol);

        }

    }

    [Command]
    void CmdIndiSpawn(Vector3 pos0, Quaternion rot0, Vector3 pos1, Quaternion rot1, Vector3 pos2, Quaternion rot2, Vector3 pos3, Quaternion rot3)
    {
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            GameObject spawnNetworkIndiG = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/indicatorG"), pos0, rot0);
            NetworkServer.Spawn(spawnNetworkIndiG);

            GameObject spawnNetworkIndiR = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/indicatorR"), pos1, rot1);
            NetworkServer.Spawn(spawnNetworkIndiR);

            GameObject spawnNetworkIndiY = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/indicatorY"), pos2, rot2);
            NetworkServer.Spawn(spawnNetworkIndiY);

            GameObject spawnNetworkIndiB = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/indicatorB"), pos3, rot3);
            NetworkServer.Spawn(spawnNetworkIndiB);
        }

    }

    [Command]
    void CmdbannerSpawn(Vector3 pos0, Quaternion rot0, Vector3 pos1, Quaternion rot1, Vector3 pos2, Quaternion rot2, Vector3 pos3, Quaternion rot3)
    {
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            GameObject spawnNetworkBannerG = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Green Banners"), pos0, rot0);
            NetworkServer.Spawn(spawnNetworkBannerG);

            GameObject spawnNetworkBannerR = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Red Banners"), pos1, rot1);
            NetworkServer.Spawn(spawnNetworkBannerR);

            GameObject spawnNetworkBannerY = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Orange Banners"), pos2, rot2);
            NetworkServer.Spawn(spawnNetworkBannerY);

            GameObject spawnNetworkBannerB = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Blue Banners"), pos3, rot3);
            NetworkServer.Spawn(spawnNetworkBannerB);
        }

    }
}
