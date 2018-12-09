﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class SceneController : Photon.PunBehaviour {

	public string YourBirealityUsername = "";
	public string YourRoomTitle = "";
	public byte MaxPlayers = 0;

	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	public override void OnConnectedToMaster () {
		RoomOptions room_options = new RoomOptions();
		room_options.IsVisible = true;
		room_options.MaxPlayers = MaxPlayers;
		PhotonNetwork.CreateRoom(YourBirealityUsername + YourRoomTitle, room_options, TypedLobby.Default);
	}

	public override void OnJoinedRoom () {
		InstantiateSceneObjects();
	}

	public override void OnPhotonPlayerConnected (PhotonPlayer player) {
		InstantiatePlayerObjects(player);
	}

	public void InstantiateSceneObjects () {
		// Instantiate objects in your scene. Prefabs must be available in folder "Resources". 
		// Example: 
		//     PhotonNetwork.Instantiate("scene_object", Vector3.zero, Quaternion.identity, 0);

		PhotonNetwork.Instantiate("room", new Vector3(-36f, 3.907689f, 68f), Quaternion.Euler(0f, 180f, 0f), 0);
		PhotonNetwork.Instantiate("furnitures", Vector3.zero, Quaternion.identity, 0);
	}

	public void InstantiatePlayerObjects (PhotonPlayer player) {
		// Instantiate objects for a connected player. Prefabs must be available in folder "Resources". 
		// Example: 
		//     GameObject avatar = PhotonNetwork.Instantiate("player_object", Vector3.zero, Quaternion.identity, 0);
		//     avatar.GetComponent<PhotonView>().TransferOwnership(player);

	}

}
