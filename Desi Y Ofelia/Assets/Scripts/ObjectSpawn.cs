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
    public GameObject CageSwitch;
    public GameObject DoorSwitch;
	public GameObject level0banner;
	public GameObject level1banner;
	public GameObject level1banner1;


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
        CmdswitchSpawn(CageSwitch.transform.position, CageSwitch.transform.rotation, DoorSwitch.transform.position, DoorSwitch.transform.rotation);
		CmdLevel0Spawn(level0banner.transform.position, level0banner.transform.rotation);
		CmdLevel1Spawn(level1banner.transform.position, level1banner.transform.rotation, level1banner1.transform.position, level1banner1.transform.rotation );
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
            Vector3 newpos = new Vector3(24, 0.65f, 12f);
            GameObject spawnNetworkCage = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/cage"), newpos, rot);
            NetworkServer.Spawn(spawnNetworkCage);
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            Vector3 newpos = new Vector3(-25, 2.1f, 25f);
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
            Vector3 newpos = new Vector3(24, 0.3f, 12f);
            GameObject spawnNetworkcandle = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CandleHolder"), newpos, rot);
            NetworkServer.Spawn(spawnNetworkcandle);
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            Vector3 newpos = new Vector3(-25, 1.8f, 25f);
            GameObject spawnNetworkcandle = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CandleHolder"), newpos, rot);
            NetworkServer.Spawn(spawnNetworkcandle);

        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            Vector3 newpos = new Vector3(-29, 0.5f, 15f);
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

    [Command]
    void CmdswitchSpawn(Vector3 pos1, Quaternion rot1, Vector3 pos2, Quaternion rot2)
    {
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            GameObject spawnNetworkCageSwitch = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CageSwitch"), pos1, rot1);
            NetworkServer.Spawn(spawnNetworkCageSwitch);

            GameObject spawnNetworkDoorSwitch = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/DoorSwitch"), pos2, rot2);
            NetworkServer.Spawn(spawnNetworkDoorSwitch);
        }
    }

	[Command]
	void CmdLevel0Spawn(Vector3 pos, Quaternion rot)
	{
		if (SceneManager.GetActiveScene ().name == "Level 0") 
		{
			GameObject Banners = (GameObject)Instantiate (Resources.Load<GameObject> ("Prefabs/Level 0/Banner Holder"), pos, rot);
			NetworkServer.Spawn (Banners);
		}
	}

	[Command]
	void CmdLevel1Spawn(Vector3 pos, Quaternion rot, Vector3 pos1, Quaternion rot1)
	{
		if (SceneManager.GetActiveScene ().name == "Level 1") 
		{
			GameObject Banners = (GameObject)Instantiate (Resources.Load<GameObject> ("Prefabs/Level 1/Banner Holder"), pos, rot);
			NetworkServer.Spawn (Banners);

			GameObject Banners1 = (GameObject)Instantiate (Resources.Load<GameObject> ("Prefabs/Level 1/Banner Holder1"), pos1, rot1);
			NetworkServer.Spawn (Banners1);
		}
	}
}
