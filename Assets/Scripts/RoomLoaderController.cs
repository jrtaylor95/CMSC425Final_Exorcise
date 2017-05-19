using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoaderController : MonoBehaviour {
	public GameObject exit;

	public Vector2 GetExitPosition() {
		return exit.transform.position;
	}

	public float GetRoomZ() {
		return exit.transform.position.z;
	}
}
