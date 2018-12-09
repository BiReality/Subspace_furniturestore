# BiReality SDK

## Introduction

This repo contains SDK to help you create rooms in BiReality. 

To create a room in BiReality, you will first build a VR scene with Unity. Then you will register the room in BiReality console and upload resources of the room to our server. Finally you will host your room with Photon Engine. 

## Prerequisites

0. Sign up at BiReality console `http://35.238.132.51:8080`. This will be your BiReality account both as a builder and as a regular user. 

0. Sign up at Photon Engine `https://www.photonengine.com` and create a Photon Cloud Application of type `Realtime`. This will allocate a free, dedicated server to host your room (max concurrent user (CCU) is 20). Retrieve the associated `App ID`. If you wish to use our shared server `App ID = 587d3901-3e5f-441c-928a-be2ce2e9115b`, you can skip this step. 

## How to use this SDK to build a room in BiReality? 

0. Create a new Unity project

0. Import the following packages from Unity Asset Store: 

	* Photon Unity Networking Classic - FREE
	* SteamVR Plugin
	* VRTK - Virtual Reality Toolkit

0. Download the latest release `BiReality_SDK.unitypackage` from this repo, and import it into your project

0. Scene

	* Create an empty GameObject `SceneController` that has component `SceneController.cs`. Fill in parameters. 
	* In `SceneController.cs`, implement `InstantiateSceneObjects()` and `InstantiatePlayerObjects()`. 
	* In `ObjectController.cs`, implement `InteractUse()`. 

0. Objects

	* All Prefabs should be placed in folder `Resources`. 
	* If a GameObject is visible over network, its Prefab should have the following components: 
		* `PhotonView`
	* If a GameObject is interactable, its Prefab should have the following components: 
		* `RpcReceiver.cs` (a placeholder for terminal-side script)
		* `CustomInteractUse.cs` (a placeholder for terminal-side script)
		* `RigidBody`
		* `Box Collider`
	* In the controller script of the object, implement this function: 
		* `[PunRPC] void InteractUse (int playerId) {}`
	* If a GameObject is grabbable, its Prefab should have the following components: 
		* `VRTK_FixedJointGrabAttach`
		* `VRTK_SwapControllerGrabAction`

## How to host a room in BiReality? 

0. Fill in your Photon `App ID` in `Assets/Photon Unity Networking/Resources/PhotonServerSettings.asset`. 

0. Build resources archive. In your Unity project, click `Build -> Build Asset Bundle`. When build succeeds, an archive `resource.zip` will appear in the project directory. 

0. Register room in BiReality console. Sign in to `http://35.238.132.51:8080` and hit `Create Room`. Fill in the room display title, Photon `App ID`, and its virtual address. Upload resources archive. 

0. Run your project in Unity. This will create an active room over network and other users can visit. If you would like to keep this room running forever, you may consider building a headerless Linux build and run it on a remote server. 

