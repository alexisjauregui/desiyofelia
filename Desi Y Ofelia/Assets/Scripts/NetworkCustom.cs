using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

[AddComponentMenu("Network/NetworkManagerHUD")]
[RequireComponent(typeof(NetworkManager))]
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public class NetworkCustom : MonoBehaviour {

    public NetworkManager manager;
    public InputField ip;
    private RawImage splash;
    private GameObject bg;

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "Start Menu")
        {
            bg = GameObject.Find("blackscreen");
            splash = GameObject.Find("Splash").GetComponent<RawImage>();
            splash.CrossFadeAlpha(0.0f, 3.0f, false);
            ip.GetComponent<InputField>().text = "128.114.52.";
        }
	}

    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Start Menu")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bg.SetActive(false);
                splash.gameObject.SetActive(false);
            }
        }
            if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                manager.StartServer();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                Host();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                Join();
            }
            manager.networkAddress = ip.GetComponent<InputField>().text;
        }
        if (NetworkServer.active && NetworkClient.active)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                manager.StopHost();
            }
        }

    }

    public void Host()
    {
        GetComponent<NetManagerCustom>().playerPrefabIndex = 0;
        manager.StartHost(); 
    }

    public void Join()
    {
        GetComponent<NetManagerCustom>().playerPrefabIndex = 1;
        manager.StartClient();
    }
}
