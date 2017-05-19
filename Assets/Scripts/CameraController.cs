using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	GameObject player;
	public bool followPlayer = true;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (followPlayer) {
			var playerPos = player.transform.position;
			playerPos.y += .13f;
			playerPos.z = -10;
//			transform.position = new Vector3(Mathf.Clamp(playerPos.x, -.2f, .2f), playerPos.y, -10);
			transform.position = playerPos;
		}
	}
}
