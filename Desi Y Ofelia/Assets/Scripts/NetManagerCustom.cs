﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MsgTypes
{
    public const short PlayerPrefab = MsgType.Highest + 1;

    public class PlayerPrefabMsg : MessageBase
    {
        public short controllerID;
        public short prefabIndex;
    }
}

public class NetManagerCustom : NetworkManager
{
    // in the Network Manager component, you must put your player prefabs 
    // in the Spawn Info -> Registered Spawnable Prefabs section 
    public short playerPrefabIndex;

    public override void OnStartServer()
    {
        NetworkServer.RegisterHandler(MsgTypes.PlayerPrefab, OnResponsePrefab);
        base.OnStartServer();
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        client.RegisterHandler(MsgTypes.PlayerPrefab, OnRequestPrefab);
        base.OnClientConnect(conn);
    }

    private void OnRequestPrefab(NetworkMessage netMsg)
    {
        MsgTypes.PlayerPrefabMsg msg = new MsgTypes.PlayerPrefabMsg();
        msg.controllerID = netMsg.ReadMessage<MsgTypes.PlayerPrefabMsg>().controllerID;
        msg.prefabIndex = playerPrefabIndex;
        client.Send(MsgTypes.PlayerPrefab, msg);
    }

    private void OnResponsePrefab(NetworkMessage netMsg)
    {
        MsgTypes.PlayerPrefabMsg msg = netMsg.ReadMessage<MsgTypes.PlayerPrefabMsg>();
        playerPrefab = spawnPrefabs[msg.prefabIndex];
        base.OnServerAddPlayer(netMsg.conn, msg.controllerID);
        Debug.Log(playerPrefab.name + " spawned!");
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        MsgTypes.PlayerPrefabMsg msg = new MsgTypes.PlayerPrefabMsg();
        msg.controllerID = playerControllerId;
        NetworkServer.SendToClient(conn.connectionId, MsgTypes.PlayerPrefab, msg);
    }

    bool HasCandle()
    {
        if (GameObject.Find("CandleHolder").transform.IsChildOf(transform))
            return true;
        return false;
    }

    // I have put a toggle UI on gameObjects called PC1 and PC2 to select two different character types.
    // on toggle, this function is called, which updates the playerPrefabIndex
    // The index will be the number from the registered spawnable prefabs that 
    // you want for your player
    public void UpdatePC()
    {
        if (GameObject.FindGameObjectWithTag("Desi").GetComponent<Toggle>().isOn)
        {
            playerPrefabIndex = 0;
            Debug.Log("You chose Desi!");
        }
        else if (GameObject.FindGameObjectWithTag("Ofelia").GetComponent<Toggle>().isOn)
        {
            playerPrefabIndex = 1;
            Debug.Log("You chose Ofelia!");
        }
    }
}
