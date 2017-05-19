using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoaderController : MonoBehaviour {
	public GameObject exit;

	bool beenFlipped = false;
	SpriteRenderer doorRenderer;

	void Start() {
		doorRenderer = GetComponent<SpriteRenderer> ();
	}

	public Vector2 GetExitPosition() {
		return exit.transform.position;
	}

	public float GetRoomZ() {
		return exit.transform.position.z;
	}
}
