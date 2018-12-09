using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhibitObjectController : MonoBehaviour {

	public string name = "";
	public string description = "";
	public string action = "";

	public float angularSpeed = 0f;

	[PunRPC]
	void InteractUse (int playerId) {
		GetComponent<PhotonView>().RPC("ToggleObjectInfoPanel", PhotonTargets.OthersBuffered, playerId, name, description, action);
	}

	void Start () {
		GetComponent<PhotonView>().RPC("SetAngularSpeed", PhotonTargets.OthersBuffered, angularSpeed);
	}

	/*
	void Update () {
		transform.Rotate(Vector3.up, angularSpeed * Time.deltaTime);
	}
	*/

}
